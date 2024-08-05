package response;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.time.LocalDate;
import java.time.OffsetDateTime;

public class FuturesResponseDataItem {
    private String symbol;
    private String productCode;
    private String contractSize;
    private String tickSize;
    private String notionalMultiplier;
    private String mainFraction;
    private String subFraction;
    private String displayFactor;
    private LocalDate lastTradeDate;
    private LocalDate expirationDate;
    private LocalDate closingOnlyDate;
    private boolean active;
    private boolean activeMonth;
    private boolean nextActiveMonth;
    private boolean isClosingOnly;
    private OffsetDateTime stopsTradingAt;
    private OffsetDateTime expiresAt;
    private String productGroup;
    private String exchange;
    private String rollTargetSymbol;
    private String streamerExchangeCode;
    private String streamerSymbol;
    private boolean backMonthFirstCalendarSymbol;
    private boolean isTradeable;
    private FutureEtfEquivalent futureEtfEquivalent;
    private FutureProduct futureProduct;
    private TickSize[] tickSizes;
    private OptionTickSize[] optionTickSizes;
    private SpreadTickSize[] spreadTickSizes;
    private LocalDate firstNoticeDate;

    @JsonProperty("symbol")
    public String getSymbol() {
        return symbol;
    }

    @JsonProperty("symbol")
    public void setSymbol(String value) {
        this.symbol = value;
    }

    @JsonProperty("product-code")
    public String getProductCode() {
        return productCode;
    }

    @JsonProperty("product-code")
    public void setProductCode(String value) {
        this.productCode = value;
    }

    @JsonProperty("contract-size")
    public String getContractSize() {
        return contractSize;
    }

    @JsonProperty("contract-size")
    public void setContractSize(String value) {
        this.contractSize = value;
    }

    @JsonProperty("tick-size")
    public String getTickSize() {
        return tickSize;
    }

    @JsonProperty("tick-size")
    public void setTickSize(String value) {
        this.tickSize = value;
    }

    @JsonProperty("notional-multiplier")
    public String getNotionalMultiplier() {
        return notionalMultiplier;
    }

    @JsonProperty("notional-multiplier")
    public void setNotionalMultiplier(String value) {
        this.notionalMultiplier = value;
    }

    @JsonProperty("main-fraction")
    public String getMainFraction() {
        return mainFraction;
    }

    @JsonProperty("main-fraction")
    public void setMainFraction(String value) {
        this.mainFraction = value;
    }

    @JsonProperty("sub-fraction")
    public String getSubFraction() {
        return subFraction;
    }

    @JsonProperty("sub-fraction")
    public void setSubFraction(String value) {
        this.subFraction = value;
    }

    @JsonProperty("display-factor")
    public String getDisplayFactor() {
        return displayFactor;
    }

    @JsonProperty("display-factor")
    public void setDisplayFactor(String value) {
        this.displayFactor = value;
    }

    @JsonProperty("last-trade-date")
    public LocalDate getLastTradeDate() {
        return lastTradeDate;
    }

    @JsonProperty("last-trade-date")
    public void setLastTradeDate(LocalDate value) {
        this.lastTradeDate = value;
    }

    @JsonProperty("expiration-date")
    public LocalDate getExpirationDate() {
        return expirationDate;
    }

    @JsonProperty("expiration-date")
    public void setExpirationDate(LocalDate value) {
        this.expirationDate = value;
    }

    @JsonProperty("closing-only-date")
    public LocalDate getClosingOnlyDate() {
        return closingOnlyDate;
    }

    @JsonProperty("closing-only-date")
    public void setClosingOnlyDate(LocalDate value) {
        this.closingOnlyDate = value;
    }

    @JsonProperty("active")
    public boolean getActive() {
        return active;
    }

    @JsonProperty("active")
    public void setActive(boolean value) {
        this.active = value;
    }

    @JsonProperty("active-month")
    public boolean getActiveMonth() {
        return activeMonth;
    }

    @JsonProperty("active-month")
    public void setActiveMonth(boolean value) {
        this.activeMonth = value;
    }

    @JsonProperty("next-active-month")
    public boolean getNextActiveMonth() {
        return nextActiveMonth;
    }

    @JsonProperty("next-active-month")
    public void setNextActiveMonth(boolean value) {
        this.nextActiveMonth = value;
    }

    @JsonProperty("is-closing-only")
    public boolean getIsClosingOnly() {
        return isClosingOnly;
    }

    @JsonProperty("is-closing-only")
    public void setIsClosingOnly(boolean value) {
        this.isClosingOnly = value;
    }

    @JsonProperty("stops-trading-at")
    public OffsetDateTime getStopsTradingAt() {
        return stopsTradingAt;
    }

    @JsonProperty("stops-trading-at")
    public void setStopsTradingAt(OffsetDateTime value) {
        this.stopsTradingAt = value;
    }

    @JsonProperty("expires-at")
    public OffsetDateTime getExpiresAt() {
        return expiresAt;
    }

    @JsonProperty("expires-at")
    public void setExpiresAt(OffsetDateTime value) {
        this.expiresAt = value;
    }

    @JsonProperty("product-group")
    public String getProductGroup() {
        return productGroup;
    }

    @JsonProperty("product-group")
    public void setProductGroup(String value) {
        this.productGroup = value;
    }

    @JsonProperty("exchange")
    public String getExchange() {
        return exchange;
    }

    @JsonProperty("exchange")
    public void setExchange(String value) {
        this.exchange = value;
    }

    @JsonProperty("roll-target-symbol")
    public String getRollTargetSymbol() {
        return rollTargetSymbol;
    }

    @JsonProperty("roll-target-symbol")
    public void setRollTargetSymbol(String value) {
        this.rollTargetSymbol = value;
    }

    @JsonProperty("streamer-exchange-code")
    public String getStreamerExchangeCode() {
        return streamerExchangeCode;
    }

    @JsonProperty("streamer-exchange-code")
    public void setStreamerExchangeCode(String value) {
        this.streamerExchangeCode = value;
    }

    @JsonProperty("streamer-symbol")
    public String getStreamerSymbol() {
        return streamerSymbol;
    }

    @JsonProperty("streamer-symbol")
    public void setStreamerSymbol(String value) {
        this.streamerSymbol = value;
    }

    @JsonProperty("back-month-first-calendar-symbol")
    public boolean getBackMonthFirstCalendarSymbol() {
        return backMonthFirstCalendarSymbol;
    }

    @JsonProperty("back-month-first-calendar-symbol")
    public void setBackMonthFirstCalendarSymbol(boolean value) {
        this.backMonthFirstCalendarSymbol = value;
    }

    @JsonProperty("is-tradeable")
    public boolean getIsTradeable() {
        return isTradeable;
    }

    @JsonProperty("is-tradeable")
    public void setIsTradeable(boolean value) {
        this.isTradeable = value;
    }

    @JsonProperty("future-etf-equivalent")
    public FutureEtfEquivalent getFutureEtfEquivalent() {
        return futureEtfEquivalent;
    }

    @JsonProperty("future-etf-equivalent")
    public void setFutureEtfEquivalent(FutureEtfEquivalent value) {
        this.futureEtfEquivalent = value;
    }

    @JsonProperty("future-product")
    public FutureProduct getFutureProduct() {
        return futureProduct;
    }

    @JsonProperty("future-product")
    public void setFutureProduct(FutureProduct value) {
        this.futureProduct = value;
    }

    @JsonProperty("tick-sizes")
    public TickSize[] getTickSizes() {
        return tickSizes;
    }

    @JsonProperty("tick-sizes")
    public void setTickSizes(TickSize[] value) {
        this.tickSizes = value;
    }

    @JsonProperty("option-tick-sizes")
    public OptionTickSize[] getOptionTickSizes() {
        return optionTickSizes;
    }

    @JsonProperty("option-tick-sizes")
    public void setOptionTickSizes(OptionTickSize[] value) {
        this.optionTickSizes = value;
    }

    @JsonProperty("spread-tick-sizes")
    public SpreadTickSize[] getSpreadTickSizes() {
        return spreadTickSizes;
    }

    @JsonProperty("spread-tick-sizes")
    public void setSpreadTickSizes(SpreadTickSize[] value) {
        this.spreadTickSizes = value;
    }

    @JsonProperty("first-notice-date")
    public LocalDate getFirstNoticeDate() {
        return firstNoticeDate;
    }

    @JsonProperty("first-notice-date")
    public void setFirstNoticeDate(LocalDate value) {
        this.firstNoticeDate = value;
    }
}
