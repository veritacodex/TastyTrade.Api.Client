package request;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.databind.*;
import com.fasterxml.jackson.databind.module.SimpleModule;
import com.fasterxml.jackson.core.JsonProcessingException;
import helper.JsonFormatter;

import java.io.IOException;
import java.time.OffsetDateTime;

public class AuthenticationRequest {

    private String login;
    private String password;
    private boolean rememberMe;
    private String userAgent;
    private String apiBaseURL;

    @JsonProperty("login")
    public String getLogin() { return login; }
    @JsonProperty("login")
    public void setLogin(String value) { this.login = value; }

    @JsonProperty("password")
    public String getPassword() { return password; }
    @JsonProperty("password")
    public void setPassword(String value) { this.password = value; }

    @JsonProperty("remember-me")
    public boolean getRememberMe() { return rememberMe; }
    @JsonProperty("remember-me")
    public void setRememberMe(boolean value) { this.rememberMe = value; }

    @JsonProperty("user-agent")
    public String getUserAgent() { return userAgent; }
    @JsonProperty("user-agent")
    public void setUserAgent(String value) { this.userAgent = value; }

    @JsonProperty("api-base-url")
    public String getAPIBaseURL() { return apiBaseURL; }
    @JsonProperty("api-base-url")
    public void setAPIBaseURL(String value) { this.apiBaseURL = value; }

    public static AuthenticationRequest fromJsonString(String json) throws IOException {
        return getObjectReader().readValue(json);
    }

    public static String toJsonString(AuthenticationRequest obj) throws JsonProcessingException {
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
        reader = mapper.readerFor(AuthenticationRequest.class);
        writer = mapper.writerFor(AuthenticationRequest.class);
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