package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class User {
    private String email;
    private String externalID;
    private boolean isConfirmed;
    private String username;

    @JsonProperty("email")
    public String getEmail() {
        return email;
    }

    @JsonProperty("email")
    public void setEmail(String value) {
        this.email = value;
    }

    @JsonProperty("external-id")
    public String getExternalID() {
        return externalID;
    }

    @JsonProperty("external-id")
    public void setExternalID(String value) {
        this.externalID = value;
    }

    @JsonProperty("is-confirmed")
    public boolean getIsConfirmed() {
        return isConfirmed;
    }

    @JsonProperty("is-confirmed")
    public void setIsConfirmed(boolean value) {
        this.isConfirmed = value;
    }

    @JsonProperty("username")
    public String getUsername() {
        return username;
    }

    @JsonProperty("username")
    public void setUsername(String value) {
        this.username = value;
    }
}