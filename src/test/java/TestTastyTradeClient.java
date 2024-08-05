import client.TastyTradeClient;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import request.AuthenticationRequest;
import response.AuthenticationResponse;
import response.CustomerResponse;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;
import java.util.concurrent.ExecutionException;
import java.util.logging.Logger;

import static org.junit.jupiter.api.Assertions.assertNotNull;

public class TestTastyTradeClient {
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
    public void TestAuthentication() throws IOException, ExecutionException, InterruptedException {
        TastyTradeClient client = new TastyTradeClient();
        AuthenticationResponse response = client.Authenticate(request);
        assertNotNull(response.getData().getSessionToken());
    }

    @Test
    public void TestCustomer() throws IOException, ExecutionException, InterruptedException {
        TastyTradeClient client = new TastyTradeClient();
        client.Authenticate(request);
        CustomerResponse response = client.GetCustomer();
        assertNotNull(response.getData().getAddress());
    }
}
