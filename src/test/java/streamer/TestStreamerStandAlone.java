package streamer;

import client.TastyTradeClient;
import com.dxfeed.api.DXEndpoint;
import com.dxfeed.api.DXFeedSubscription;
import com.dxfeed.event.market.Quote;
import common.PropertiesHelper;
import request.AuthenticationRequest;
import response.APIQuoteTokensResponse;
import java.io.IOException;
import java.util.Properties;
import java.util.concurrent.ExecutionException;

public class TestStreamerStandAlone {
    public static void main(String[] args) throws InterruptedException, IOException, ExecutionException {

        Properties properties = PropertiesHelper.getProperties("credentials.properties");
        assert properties != null;

        AuthenticationRequest request = new AuthenticationRequest();
        request.setLogin(properties.getProperty("login"));
        request.setPassword(properties.getProperty("password"));
        request.setUserAgent(properties.getProperty("user-agent"));
        request.setAPIBaseURL(properties.getProperty("api-root"));
        request.setRememberMe(true);

        TastyTradeClient client = new TastyTradeClient();
        client.authenticate(request);
        APIQuoteTokensResponse response = client.getApiQuoteTokens();

        System.setProperty("dxfeed.experimental.dxlink.enable", "true");
        System.setProperty("scheme", "ext:opt:sysprops,resource:dxlink.xml");
        try (DXEndpoint dxEndpoint = DXEndpoint.create()) {
            dxEndpoint.connect("dxlink:wss://demo.dxfeed.com/dxlink-ws");
            try (DXFeedSubscription<Quote> subscription = dxEndpoint.getFeed().createSubscription(Quote.class)) {
                subscription.addEventListener(events -> {
                    for (Quote event : events) {
                        System.out.println(event);
                    }
                });
                subscription.addSymbols("AAPL");
            }
        }
        Thread.sleep(Long.MAX_VALUE);
    }
}
