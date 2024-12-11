using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;
using TastyTrade.Client.Model.Request;
using System.Collections.Generic;

namespace TastyTrade.Client.Tests.Serialization
{
    public class ModelEnumSerializerTests
    {
        [SetUp]
        public void Setup()
        {

        }
        public class FlatEnumValueAttributeName
        {
            public Type EnumType { get; set; }
            public object EnumValue { get; set; }
            public string EnumValueName { get; set; }
            public string EnumValueNameSerializationName { get; set; }

            public string GetTypeName()
            {
                return $"EnumTypeTest{this.EnumType.Name}{this.EnumValueName}";
            }
        }

        private static List<FlatEnumValueAttributeName> GetEnumsWithSerializationAttributes()
        {
            var assemblyNamePrefix = typeof(PlaceOrderRequest).FullName.Split('.')[0];
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).ToList();
            var tastytypes = allTypes.FirstOrDefault(t => 
                !string.IsNullOrEmpty(t.Namespace) && 
                t.Namespace.ToLower().Contains("tasty", StringComparison.Ordinal));
            var tastyEnums = allTypes.Where(t => 
                t != null && 
                (!string.IsNullOrWhiteSpace(t.Namespace)) && 
                t.Namespace.StartsWith(assemblyNamePrefix) && t.IsEnum).ToList();
            var enumValuesList = new List<FlatEnumValueAttributeName>();
            tastyEnums.ForEach(enumType =>
            {
                var enumValues = Enum.GetValues(enumType);

                foreach (var enumValue in enumValues)
                {
                    var enumName = Enum.GetName(enumType, enumValue);
                    var memberInfos = enumType.GetMember(enumName);
                    var enumValueMemberInfo = memberInfos.FirstOrDefault(m =>
                    m.DeclaringType == enumType);
                    var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(JsonStringEnumMemberNameAttribute), false);
                    if (valueAttributes.Length > 0)
                    {
                        var description = ((JsonStringEnumMemberNameAttribute)valueAttributes[0]).Name;
                        enumValuesList.Add(new FlatEnumValueAttributeName()
                        {
                            EnumType = enumType,
                            EnumValue = enumValue,
                            EnumValueName = enumName,
                            EnumValueNameSerializationName = description
                        });
                    }
                }
            });
            return enumValuesList;
        }

        [Test]
        public void EnumsWithValueAttributes_Serialize_Correctly()
        {
            var order = new PlaceOrderRequest()
            {
                OrderType = OrderType.StopLimit,
                Legs = [
                     new OrderSubmissionLeg() {
                         Action = OrderLegAction.BuyToClose,
                         InstrumentType = InstrumentType.EquityOption
                     }
                 ]
            };

            var enumValuesToTest = GetEnumsWithSerializationAttributes();
            var testEnumTypes = BuildDynamicTypeWithProperties(enumValuesToTest);

            foreach (var testableEnumValue in testEnumTypes)
            {
                var propName = testableEnumValue.Key.EnumValueName;
                var shouldBeTypeName = testableEnumValue.Key.GetTypeName();
                var enumProp = testableEnumValue.Value.GetType().GetProperties().FirstOrDefault(p => p.Name == propName);
                var enumParse = Enum.Parse(testableEnumValue.Key.EnumType, testableEnumValue.Key.EnumValue.ToString());
                var enumValue = Enum.ToObject(testableEnumValue.Key.EnumType, enumParse);

                var testableObj = testableEnumValue.Value;
                enumProp.SetValue(testableObj, enumValue);

                var jsonOrder = JsonSerializer.Serialize(testableEnumValue.Value);
                var rehydratedOrder = JsonSerializer.Deserialize(jsonOrder, testableEnumValue.Value.GetType());
                var actual = enumProp.GetValue(rehydratedOrder);

                Assert.That(jsonOrder, Does.Contain(testableEnumValue.Key.EnumValueNameSerializationName), $"json should contain {testableEnumValue.Key.EnumValueNameSerializationName} but doesn't");
                Assert.That(actual, Is.EqualTo(testableEnumValue.Key.EnumValue));
            }
        }


        /// <summary>
        /// Creates types in memory for testing (de)serialization for all enumerations
        /// </summary>
        /// <param name="enumsValues2Test"></param>
        /// <returns></returns>
        private static Dictionary<FlatEnumValueAttributeName, object> BuildDynamicTypeWithProperties(List<FlatEnumValueAttributeName> enumsValues2Test)
        {
            var types2Test = enumsValues2Test.ToDictionary(k => k, k => new object());
            AppDomain myDomain = Thread.GetDomain();
            AssemblyName myAsmName = new()
            {
                Name = "TastySerializationTesting"
            };

            AssemblyBuilder myAsmBuilder = AssemblyBuilder.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run);
            ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(myAsmName.Name + ".dll");
            foreach (var type2Test in enumsValues2Test)
            {
                var enumType2Test = type2Test.GetTypeName();
                TypeBuilder myTypeBuilder = myModBuilder.DefineType(enumType2Test, TypeAttributes.Public);

                FieldBuilder enumTestFieldBldr = myTypeBuilder.DefineField($"{type2Test.EnumValueName.ToLower()}",
                                                                type2Test.EnumType,
                                                                FieldAttributes.Private);

                PropertyBuilder enumTestPropBldr = myTypeBuilder.DefineProperty($"{type2Test.EnumValueName}",
                                                                PropertyAttributes.HasDefault,
                                                                type2Test.EnumType,
                                                                null);

                var attrCtorParams = new Type[] { typeof(Type) };
                var attrCtorInfo = typeof(JsonConverterAttribute).GetConstructor(attrCtorParams);
                var attrBuilder = new CustomAttributeBuilder(attrCtorInfo, [typeof(JsonStringEnumConverter)]);
                enumTestPropBldr.SetCustomAttribute(attrBuilder);

                MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;

                MethodBuilder enumTestGetPropMthdBldr =
                    myTypeBuilder.DefineMethod($"get_{type2Test.EnumValueName}",
                                               getSetAttr,
                                               type2Test.EnumType,
                                               Type.EmptyTypes);

                ILGenerator enumTestGetIL = enumTestGetPropMthdBldr.GetILGenerator();
                //dark magic
                enumTestGetIL.Emit(OpCodes.Ldarg_0);
                enumTestGetIL.Emit(OpCodes.Ldfld, enumTestFieldBldr);
                enumTestGetIL.Emit(OpCodes.Ret);

                MethodBuilder enumTestSetPropMthdBldr =
                    myTypeBuilder.DefineMethod($"set_{type2Test.EnumValueName}",
                                               getSetAttr,
                                               null,
                                               [type2Test.EnumType]);

                ILGenerator custNameSetIL = enumTestSetPropMthdBldr.GetILGenerator();

                custNameSetIL.Emit(OpCodes.Ldarg_0);
                custNameSetIL.Emit(OpCodes.Ldarg_1);
                custNameSetIL.Emit(OpCodes.Stfld, enumTestFieldBldr);
                custNameSetIL.Emit(OpCodes.Ret);

                enumTestPropBldr.SetGetMethod(enumTestGetPropMthdBldr);
                enumTestPropBldr.SetSetMethod(enumTestSetPropMthdBldr);

                Type retval = myTypeBuilder.CreateType();

                var testableInstance = myModBuilder.Assembly.CreateInstance(enumType2Test);
                types2Test[type2Test] = testableInstance;
            }
            return types2Test;
        }
    }
}