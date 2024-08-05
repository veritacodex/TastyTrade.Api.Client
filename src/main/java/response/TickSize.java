package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class TickSize {
    private String value;

    @JsonProperty("value")
    public String getValue() {
        return value;
    }

    @JsonProperty("value")
    public void setValue(String value) {
        this.value = value;
    }
}
