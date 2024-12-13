using System;
using System.Diagnostics.CodeAnalysis;

namespace TastyTrade.Client.Utils;

public static class Guard
{
    public static void NotNull<T>([NotNull] T value, string name) where T : class
    {
        if (value == null)
        {
            throw new ArgumentNullException(name);
        }
    }
}
