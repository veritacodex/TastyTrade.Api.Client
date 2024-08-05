package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Roll {
    private String name;
    private long activeCount;
    private boolean cashSettled;
    private long businessDaysOffset;
    private boolean firstNotice;

    @JsonProperty("name")
    public String getName() {
        return name;
    }

    @JsonProperty("name")
    public void setName(String value) {
        this.name = value;
    }

    @JsonProperty("active-count")
    public long getActiveCount() {
        return activeCount;
    }

    @JsonProperty("active-count")
    public void setActiveCount(long value) {
        this.activeCount = value;
    }

    @JsonProperty("cash-settled")
    public boolean getCashSettled() {
        return cashSettled;
    }

    @JsonProperty("cash-settled")
    public void setCashSettled(boolean value) {
        this.cashSettled = value;
    }

    @JsonProperty("business-days-offset")
    public long getBusinessDaysOffset() {
        return businessDaysOffset;
    }

    @JsonProperty("business-days-offset")
    public void setBusinessDaysOffset(long value) {
        this.businessDaysOffset = value;
    }

    @JsonProperty("first-notice")
    public boolean getFirstNotice() {
        return firstNotice;
    }

    @JsonProperty("first-notice")
    public void setFirstNotice(boolean value) {
        this.firstNotice = value;
    }
}
