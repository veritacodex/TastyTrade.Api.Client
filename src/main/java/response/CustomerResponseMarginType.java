package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CustomerResponseMarginType {
    private CustomerResponseMarginTypeName name;
    private boolean isMargin;

    @JsonProperty("name")
    public CustomerResponseMarginTypeName getName() {
        return name;
    }

    @JsonProperty("name")
    public void setName(CustomerResponseMarginTypeName value) {
        this.name = value;
    }

    @JsonProperty("is_margin")
    public boolean getIsMargin() {
        return isMargin;
    }

    @JsonProperty("is_margin")
    public void setIsMargin(boolean value) {
        this.isMargin = value;
    }
}
