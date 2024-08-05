package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class AccountsResponseDataItem {
    private Account account;
    private String authorityLevel;

    @JsonProperty("account")
    public Account getAccount() {
        return account;
    }

    @JsonProperty("account")
    public void setAccount(Account value) {
        this.account = value;
    }

    @JsonProperty("authority-level")
    public String getAuthorityLevel() {
        return authorityLevel;
    }

    @JsonProperty("authority-level")
    public void setAuthorityLevel(String value) {
        this.authorityLevel = value;
    }
}