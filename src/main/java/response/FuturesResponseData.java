package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class FuturesResponseData {
    private FuturesResponseDataItem[] items;

    @JsonProperty("items")
    public FuturesResponseDataItem[] getItems() {
        return items;
    }

    @JsonProperty("items")
    public void setItems(FuturesResponseDataItem[] value) {
        this.items = value;
    }
}
