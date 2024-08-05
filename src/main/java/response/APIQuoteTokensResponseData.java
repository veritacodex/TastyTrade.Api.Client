package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class APIQuoteTokensResponseData {
    private String token;
    private String dxlinkURL;
    private String level;

    @JsonProperty("token")
    public String getToken() {
        return token;
    }

    @JsonProperty("token")
    public void setToken(String value) {
        this.token = value;
    }

    @JsonProperty("dxlink-url")
    public String getDxlinkURL() {
        return dxlinkURL;
    }

    @JsonProperty("dxlink-url")
    public void setDxlinkURL(String value) {
        this.dxlinkURL = value;
    }

    @JsonProperty("level")
    public String getLevel() {
        return level;
    }

    @JsonProperty("level")
    public void setLevel(String value) {
        this.level = value;
    }
}
