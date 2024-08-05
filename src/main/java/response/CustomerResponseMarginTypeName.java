package response;

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonValue;

import java.io.IOException;

public enum CustomerResponseMarginTypeName {
    CASH, CASH_SECURED_MARGIN, IRA_MARGIN, PORTFOLIO_MARGIN, REG_T;

    @JsonValue
    public String toValue() {
        return switch (this) {
            case CASH -> "Cash";
            case CASH_SECURED_MARGIN -> "Cash Secured Margin";
            case IRA_MARGIN -> "IRA Margin";
            case PORTFOLIO_MARGIN -> "Portfolio Margin";
            case REG_T -> "Reg T";
        };
    }

    @JsonCreator
    public static CustomerResponseMarginTypeName forValue(String value) throws IOException {
        return switch (value) {
            case "Cash" -> CASH;
            case "Cash Secured Margin" -> CASH_SECURED_MARGIN;
            case "IRA Margin" -> IRA_MARGIN;
            case "Portfolio Margin" -> PORTFOLIO_MARGIN;
            case "Reg T" -> REG_T;
            default -> throw new IOException("Cannot deserialize Name");
        };
    }
}