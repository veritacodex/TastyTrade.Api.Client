package response;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.time.OffsetDateTime;

public class Account {
    private String accountNumber;
    private OffsetDateTime openedAt;
    private String nickname;
    private String accountTypeName;
    private boolean dayTraderStatus;
    private boolean isClosed;
    private boolean isFirmError;
    private boolean isFirmProprietary;
    private boolean isFuturesApproved;
    private boolean isTestDrive;
    private String marginOrCash;
    private boolean isForeign;
    private String investmentObjective;
    private String suitableOptionsLevel;
    private OffsetDateTime createdAt;

    @JsonProperty("account-number")
    public String getAccountNumber() {
        return accountNumber;
    }

    @JsonProperty("account-number")
    public void setAccountNumber(String value) {
        this.accountNumber = value;
    }

    @JsonProperty("opened-at")
    public OffsetDateTime getOpenedAt() {
        return openedAt;
    }

    @JsonProperty("opened-at")
    public void setOpenedAt(OffsetDateTime value) {
        this.openedAt = value;
    }

    @JsonProperty("nickname")
    public String getNickname() {
        return nickname;
    }

    @JsonProperty("nickname")
    public void setNickname(String value) {
        this.nickname = value;
    }

    @JsonProperty("account-type-name")
    public String getAccountTypeName() {
        return accountTypeName;
    }

    @JsonProperty("account-type-name")
    public void setAccountTypeName(String value) {
        this.accountTypeName = value;
    }

    @JsonProperty("day-trader-status")
    public boolean getDayTraderStatus() {
        return dayTraderStatus;
    }

    @JsonProperty("day-trader-status")
    public void setDayTraderStatus(boolean value) {
        this.dayTraderStatus = value;
    }

    @JsonProperty("is-closed")
    public boolean getIsClosed() {
        return isClosed;
    }

    @JsonProperty("is-closed")
    public void setIsClosed(boolean value) {
        this.isClosed = value;
    }

    @JsonProperty("is-firm-error")
    public boolean getIsFirmError() {
        return isFirmError;
    }

    @JsonProperty("is-firm-error")
    public void setIsFirmError(boolean value) {
        this.isFirmError = value;
    }

    @JsonProperty("is-firm-proprietary")
    public boolean getIsFirmProprietary() {
        return isFirmProprietary;
    }

    @JsonProperty("is-firm-proprietary")
    public void setIsFirmProprietary(boolean value) {
        this.isFirmProprietary = value;
    }

    @JsonProperty("is-futures-approved")
    public boolean getIsFuturesApproved() {
        return isFuturesApproved;
    }

    @JsonProperty("is-futures-approved")
    public void setIsFuturesApproved(boolean value) {
        this.isFuturesApproved = value;
    }

    @JsonProperty("is-test-drive")
    public boolean getIsTestDrive() {
        return isTestDrive;
    }

    @JsonProperty("is-test-drive")
    public void setIsTestDrive(boolean value) {
        this.isTestDrive = value;
    }

    @JsonProperty("margin-or-cash")
    public String getMarginOrCash() {
        return marginOrCash;
    }

    @JsonProperty("margin-or-cash")
    public void setMarginOrCash(String value) {
        this.marginOrCash = value;
    }

    @JsonProperty("is-foreign")
    public boolean getIsForeign() {
        return isForeign;
    }

    @JsonProperty("is-foreign")
    public void setIsForeign(boolean value) {
        this.isForeign = value;
    }

    @JsonProperty("investment-objective")
    public String getInvestmentObjective() {
        return investmentObjective;
    }

    @JsonProperty("investment-objective")
    public void setInvestmentObjective(String value) {
        this.investmentObjective = value;
    }

    @JsonProperty("suitable-options-level")
    public String getSuitableOptionsLevel() {
        return suitableOptionsLevel;
    }

    @JsonProperty("suitable-options-level")
    public void setSuitableOptionsLevel(String value) {
        this.suitableOptionsLevel = value;
    }

    @JsonProperty("created-at")
    public OffsetDateTime getCreatedAt() {
        return createdAt;
    }

    @JsonProperty("created-at")
    public void setCreatedAt(OffsetDateTime value) {
        this.createdAt = value;
    }
}
