package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CustomerResponseAddress {
    private String streetOne;
    private String city;
    private String stateRegion;
    private String postalCode;
    private String country;
    private boolean isForeign;
    private boolean isDomestic;

    @JsonProperty("street-one")
    public String getStreetOne() {
        return streetOne;
    }

    @JsonProperty("street-one")
    public void setStreetOne(String value) {
        this.streetOne = value;
    }

    @JsonProperty("city")
    public String getCity() {
        return city;
    }

    @JsonProperty("city")
    public void setCity(String value) {
        this.city = value;
    }

    @JsonProperty("state-region")
    public String getStateRegion() {
        return stateRegion;
    }

    @JsonProperty("state-region")
    public void setStateRegion(String value) {
        this.stateRegion = value;
    }

    @JsonProperty("postal-code")
    public String getPostalCode() {
        return postalCode;
    }

    @JsonProperty("postal-code")
    public void setPostalCode(String value) {
        this.postalCode = value;
    }

    @JsonProperty("country")
    public String getCountry() {
        return country;
    }

    @JsonProperty("country")
    public void setCountry(String value) {
        this.country = value;
    }

    @JsonProperty("is-foreign")
    public boolean getIsForeign() {
        return isForeign;
    }

    @JsonProperty("is-foreign")
    public void setIsForeign(boolean value) {
        this.isForeign = value;
    }

    @JsonProperty("is-domestic")
    public boolean getIsDomestic() {
        return isDomestic;
    }

    @JsonProperty("is-domestic")
    public void setIsDomestic(boolean value) {
        this.isDomestic = value;
    }
}
