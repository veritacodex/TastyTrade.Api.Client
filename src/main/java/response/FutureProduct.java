package response;

import com.fasterxml.jackson.annotation.JsonProperty;

public class FutureProduct {
    private String rootSymbol;
    private String code;
    private String description;
    private String clearingCode;
    private String clearingExchangeCode;
    private String clearportCode;
    private String legacyCode;
    private String exchange;
    private String legacyExchangeCode;
    private String productType;
    private String[] listedMonths;
    private String[] activeMonths;
    private String notionalMultiplier;
    private String tickSize;
    private String displayFactor;
    private String streamerExchangeCode;
    private boolean smallNotional;
    private boolean backMonthFirstCalendarSymbol;
    private boolean firstNotice;
    private boolean cashSettled;
    private String securityGroup;
    private String marketSector;
    private Roll roll;

    @JsonProperty("root-symbol")
    public String getRootSymbol() { return rootSymbol; }
    @JsonProperty("root-symbol")
    public void setRootSymbol(String value) { this.rootSymbol = value; }

    @JsonProperty("code")
    public String getCode() { return code; }
    @JsonProperty("code")
    public void setCode(String value) { this.code = value; }

    @JsonProperty("description")
    public String getDescription() { return description; }
    @JsonProperty("description")
    public void setDescription(String value) { this.description = value; }

    @JsonProperty("clearing-code")
    public String getClearingCode() { return clearingCode; }
    @JsonProperty("clearing-code")
    public void setClearingCode(String value) { this.clearingCode = value; }

    @JsonProperty("clearing-exchange-code")
    public String getClearingExchangeCode() { return clearingExchangeCode; }
    @JsonProperty("clearing-exchange-code")
    public void setClearingExchangeCode(String value) { this.clearingExchangeCode = value; }

    @JsonProperty("clearport-code")
    public String getClearportCode() { return clearportCode; }
    @JsonProperty("clearport-code")
    public void setClearportCode(String value) { this.clearportCode = value; }

    @JsonProperty("legacy-code")
    public String getLegacyCode() { return legacyCode; }
    @JsonProperty("legacy-code")
    public void setLegacyCode(String value) { this.legacyCode = value; }

    @JsonProperty("exchange")
    public String getExchange() { return exchange; }
    @JsonProperty("exchange")
    public void setExchange(String value) { this.exchange = value; }

    @JsonProperty("legacy-exchange-code")
    public String getLegacyExchangeCode() { return legacyExchangeCode; }
    @JsonProperty("legacy-exchange-code")
    public void setLegacyExchangeCode(String value) { this.legacyExchangeCode = value; }

    @JsonProperty("product-type")
    public String getProductType() { return productType; }
    @JsonProperty("product-type")
    public void setProductType(String value) { this.productType = value; }

    @JsonProperty("listed-months")
    public String[] getListedMonths() { return listedMonths; }
    @JsonProperty("listed-months")
    public void setListedMonths(String[] value) { this.listedMonths = value; }

    @JsonProperty("active-months")
    public String[] getActiveMonths() { return activeMonths; }
    @JsonProperty("active-months")
    public void setActiveMonths(String[] value) { this.activeMonths = value; }

    @JsonProperty("notional-multiplier")
    public String getNotionalMultiplier() { return notionalMultiplier; }
    @JsonProperty("notional-multiplier")
    public void setNotionalMultiplier(String value) { this.notionalMultiplier = value; }

    @JsonProperty("tick-size")
    public String getTickSize() { return tickSize; }
    @JsonProperty("tick-size")
    public void setTickSize(String value) { this.tickSize = value; }

    @JsonProperty("display-factor")
    public String getDisplayFactor() { return displayFactor; }
    @JsonProperty("display-factor")
    public void setDisplayFactor(String value) { this.displayFactor = value; }

    @JsonProperty("streamer-exchange-code")
    public String getStreamerExchangeCode() { return streamerExchangeCode; }
    @JsonProperty("streamer-exchange-code")
    public void setStreamerExchangeCode(String value) { this.streamerExchangeCode = value; }

    @JsonProperty("small-notional")
    public boolean getSmallNotional() { return smallNotional; }
    @JsonProperty("small-notional")
    public void setSmallNotional(boolean value) { this.smallNotional = value; }

    @JsonProperty("back-month-first-calendar-symbol")
    public boolean getBackMonthFirstCalendarSymbol() { return backMonthFirstCalendarSymbol; }
    @JsonProperty("back-month-first-calendar-symbol")
    public void setBackMonthFirstCalendarSymbol(boolean value) { this.backMonthFirstCalendarSymbol = value; }

    @JsonProperty("first-notice")
    public boolean getFirstNotice() { return firstNotice; }
    @JsonProperty("first-notice")
    public void setFirstNotice(boolean value) { this.firstNotice = value; }

    @JsonProperty("cash-settled")
    public boolean getCashSettled() { return cashSettled; }
    @JsonProperty("cash-settled")
    public void setCashSettled(boolean value) { this.cashSettled = value; }

    @JsonProperty("security-group")
    public String getSecurityGroup() { return securityGroup; }
    @JsonProperty("security-group")
    public void setSecurityGroup(String value) { this.securityGroup = value; }

    @JsonProperty("market-sector")
    public String getMarketSector() { return marketSector; }
    @JsonProperty("market-sector")
    public void setMarketSector(String value) { this.marketSector = value; }

    @JsonProperty("roll")
    public Roll getRoll() { return roll; }
    @JsonProperty("roll")
    public void setRoll(Roll value) { this.roll = value; }
}