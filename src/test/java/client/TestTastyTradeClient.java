package client;

import org.apache.maven.surefire.shared.io.FileUtils;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import request.AuthenticationRequest;
import response.AccountsResponse;
import response.AuthenticationResponse;
import response.CustomerResponse;
import response.FuturesResponse;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.util.Properties;
import java.util.concurrent.ExecutionException;
import java.util.logging.Logger;

import static org.junit.jupiter.api.Assertions.assertNotEquals;
import static org.junit.jupiter.api.Assertions.assertNotNull;

class TestTastyTradeClient {
    static Logger logger = Logger.getLogger(TestTastyTradeClient.class.getName());
    static Properties properties;
    private static AuthenticationRequest request;

    @BeforeAll
    static void Setup() {
        String credentialsFile = "credentials.properties";
        try (InputStream input = TestTastyTradeClient.class.getClassLoader().getResourceAsStream(credentialsFile)) {
            properties = new Properties();
            if (input == null) {
                System.out.println("Unable to find " + credentialsFile);
                return;
            }
            properties.load(input);
        } catch (IOException ex) {
            logger.severe(ex.getMessage());
        }
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
}
