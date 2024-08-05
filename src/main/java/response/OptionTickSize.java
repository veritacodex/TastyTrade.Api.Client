package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class OptionTickSize {
    private String value;
    private String threshold;

    @JsonProperty("value")
    public String getValue() {
        return value;
    }

    @JsonProperty("value")
    public void setValue(String value) {
        this.value = value;
    }

    @JsonProperty("threshold")
    public String getThreshold() {
        return threshold;
    }

    @JsonProperty("threshold")
    public void setThreshold(String value) {
        this.threshold = value;
    }
}
