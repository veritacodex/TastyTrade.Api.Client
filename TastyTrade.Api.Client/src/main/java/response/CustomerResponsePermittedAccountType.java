package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CustomerResponsePermittedAccountType {
    private String name;
    private String description;
    private boolean isTaxAdvantaged;
    private boolean hasMultipleOwners;
    private boolean isPubliclyAvailable;
    private CustomerResponseMarginType[] marginTypes;

    @JsonProperty("name")
    public String getName() {
        return name;
    }

    @JsonProperty("name")
    public void setName(String value) {
        this.name = value;
    }

    @JsonProperty("description")
    public String getDescription() {
        return description;
    }

    @JsonProperty("description")
    public void setDescription(String value) {
        this.description = value;
    }

    @JsonProperty("is_tax_advantaged")
    public boolean getIsTaxAdvantaged() {
        return isTaxAdvantaged;
    }

    @JsonProperty("is_tax_advantaged")
    public void setIsTaxAdvantaged(boolean value) {
        this.isTaxAdvantaged = value;
    }

    @JsonProperty("has_multiple_owners")
    public boolean getHasMultipleOwners() {
        return hasMultipleOwners;
    }

    @JsonProperty("has_multiple_owners")
    public void setHasMultipleOwners(boolean value) {
        this.hasMultipleOwners = value;
    }

    @JsonProperty("is_publicly_available")
    public boolean getIsPubliclyAvailable() {
        return isPubliclyAvailable;
    }

    @JsonProperty("is_publicly_available")
    public void setIsPubliclyAvailable(boolean value) {
        this.isPubliclyAvailable = value;
    }

    @JsonProperty("margin_types")
    public CustomerResponseMarginType[] getMarginTypes() {
        return marginTypes;
    }

    @JsonProperty("margin_types")
    public void setMarginTypes(CustomerResponseMarginType[] value) {
        this.marginTypes = value;
    }
}
