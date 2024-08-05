package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class FutureEtfEquivalent {
    private String symbol;
    private long shareQuantity;

    @JsonProperty("symbol")
    public String getSymbol() {
        return symbol;
    }

    @JsonProperty("symbol")
    public void setSymbol(String value) {
        this.symbol = value;
    }

    @JsonProperty("share-quantity")
    public long getShareQuantity() {
        return shareQuantity;
    }

    @JsonProperty("share-quantity")
    public void setShareQuantity(long value) {
        this.shareQuantity = value;
    }
}
