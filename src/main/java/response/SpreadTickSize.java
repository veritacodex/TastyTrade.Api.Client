package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class SpreadTickSize {
    private String value;
    private String symbol;

    @JsonProperty("value")
    public String getValue() {
        return value;
    }

    @JsonProperty("value")
    public void setValue(String value) {
        this.value = value;
    }

    @JsonProperty("symbol")
    public String getSymbol() {
        return symbol;
    }

    @JsonProperty("symbol")
    public void setSymbol(String value) {
        this.symbol = value;
    }
}