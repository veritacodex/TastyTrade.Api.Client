package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class AccountsResponseData {
    private AccountsResponseDataItem[] items;

    @JsonProperty("items")
    public AccountsResponseDataItem[] getItems() {
        return items;
    }

    @JsonProperty("items")
    public void setItems(AccountsResponseDataItem[] value) {
        this.items = value;
    }
}