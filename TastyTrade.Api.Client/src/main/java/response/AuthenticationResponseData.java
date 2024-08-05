package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class AuthenticationResponseData {
    private User user;
    private String rememberToken;
    private String sessionToken;

    @JsonProperty("user")
    public User getUser() {
        return user;
    }

    @JsonProperty("user")
    public void setUser(User value) {
        this.user = value;
    }

    @JsonProperty("remember-token")
    public String getRememberToken() {
        return rememberToken;
    }

    @JsonProperty("remember-token")
    public void setRememberToken(String value) {
        this.rememberToken = value;
    }

    @JsonProperty("session-token")
    public String getSessionToken() {
        return sessionToken;
    }

    @JsonProperty("session-token")
    public void setSessionToken(String value) {
        this.sessionToken = value;
    }
}
