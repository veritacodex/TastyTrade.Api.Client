package response;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.*;
import com.fasterxml.jackson.databind.module.SimpleModule;
import helper.JsonFormatter;

import java.io.IOException;
import java.time.OffsetDateTime;

public class FuturesSingleResponse {
    private FuturesResponseDataItem data;
    private String context;

    @JsonProperty("data")
    public FuturesResponseDataItem getData() {
        return data;
    }

    @JsonProperty("data")
    public void setData(FuturesResponseDataItem value) {
        this.data = value;
    }

    @JsonProperty("context")
    public String getContext() {
        return context;
    }

    @JsonProperty("context")
    public void setContext(String value) {
        this.context = value;
    }

    public static FuturesSingleResponse fromJsonString(String json) throws IOException {
        return getObjectReader().readValue(json);
    }

    public static String toJsonString(FuturesSingleResponse obj) throws JsonProcessingException {
        return getObjectWriter().writeValueAsString(obj);
    }

    private static ObjectReader reader;
    private static ObjectWriter writer;

    private static void instantiateMapper() {
        ObjectMapper mapper = new ObjectMapper();
        mapper.findAndRegisterModules();
        mapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
        mapper.configure(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS, false);
        SimpleModule module = new SimpleModule();
        module.addDeserializer(OffsetDateTime.class, new JsonDeserializer<OffsetDateTime>() {
            @Override
            public OffsetDateTime deserialize(JsonParser jsonParser, DeserializationContext deserializationContext) throws IOException {
                String value = jsonParser.getText();
                return JsonFormatter.parseDateTimeString(value);
            }
        });
        mapper.registerModule(module);
        reader = mapper.readerFor(FuturesSingleResponse.class);
        writer = mapper.writerFor(FuturesSingleResponse.class);
    }

    private static ObjectReader getObjectReader() {
        if (reader == null) instantiateMapper();
        return reader;
    }

    private static ObjectWriter getObjectWriter() {
        if (writer == null) instantiateMapper();
        return writer;
    }
}