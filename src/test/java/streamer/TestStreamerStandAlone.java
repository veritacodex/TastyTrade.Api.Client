package streamer;

import client.TastyTradeClient;
import common.PropertiesHelper;
import request.AuthenticationRequest;
import response.AuthenticationResponse;

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
        AuthenticationResponse response = client.authenticate(request);

    }
}
