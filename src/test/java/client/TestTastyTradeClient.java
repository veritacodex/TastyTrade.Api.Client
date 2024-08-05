package client;

import common.PropertiesHelper;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import request.AuthenticationRequest;
import response.*;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;
import java.util.concurrent.ExecutionException;

import static org.junit.jupiter.api.Assertions.assertNotEquals;
import static org.junit.jupiter.api.Assertions.assertNotNull;

class TestTastyTradeClient {
    static Properties properties;
    private static AuthenticationRequest request;

    @BeforeAll
    static void Setup() {

        properties = PropertiesHelper.getProperties("credentials.properties");
        assert properties != null;

        request = new AuthenticationRequest();
        request.setLogin(properties.getProperty("login"));
        request.setPassword(properties.getProperty("password"));
        request.setUserAgent(properties.getProperty("user-agent"));
        request.setAPIBaseURL(properties.getProperty("api-root"));
        request.setRememberMe(true);
    }

    @Test
    void TestAuthentication() throws IOException, ExecutionException, InterruptedException {
        TastyTradeClient client = new TastyTradeClient();
        AuthenticationResponse response = client.authenticate(request);
        assertNotNull(response.getData().getSessionToken());
    }

    @Test
    void TestCustomer() throws IOException, ExecutionException, InterruptedException {
        TastyTradeClient client = new TastyTradeClient();
        client.authenticate(request);
        CustomerResponse response = client.getCustomer();
        assertNotNull(response.getData().getAddress());
    }

    @Test
    void TestAccounts() throws IOException, ExecutionException, InterruptedException {
        TastyTradeClient client = new TastyTradeClient();
        client.authenticate(request);
        CustomerResponse response = client.getCustomer();
        AccountsResponse accounts = client.getAccounts(response.getData().getID());
        assertNotEquals(0, accounts.getData().getItems().length);
    }

    @Test
    void TestAllFutures() throws IOException, ExecutionException, InterruptedException {
        TastyTradeClient client = new TastyTradeClient();
        client.authenticate(request);
        FuturesResponse futures = client.getAllFutures();
        assertNotEquals(0, futures.getData().getItems().length);
    }

    @Test
    void TestFutures() throws IOException, ExecutionException, InterruptedException {
        String symbol = "ESU4"; //look for the symbol at the CME group page
        TastyTradeClient client = new TastyTradeClient();
        client.authenticate(request);
        FuturesSingleResponse response = client.getFutures(symbol);
        System.out.println(FuturesSingleResponse.toJsonString(response));
        assertNotNull(response.getData());
    }
}
