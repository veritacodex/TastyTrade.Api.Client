import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import request.AuthenticationRequest;
import response.AuthenticationResponse;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;
import java.util.concurrent.ExecutionException;
import java.util.logging.Logger;

import static org.junit.jupiter.api.Assertions.assertNotNull;

public class TestTastyTradeClient {
    static Logger logger = Logger.getLogger(TestTastyTradeClient.class.getName());
    static Properties properties;

    @BeforeAll
    static void setup() {
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
    }

    @Test
    public void testAuthentication() throws IOException, ExecutionException, InterruptedException {
        AuthenticationRequest request = new AuthenticationRequest();
        request.setLogin(properties.getProperty("login"));
        request.setPassword(properties.getProperty("password"));
        request.setUserAgent(properties.getProperty("user-agent"));
        request.setAPIBaseURL(properties.getProperty("api-root"));
        request.setRememberMe(true);
        TastyTradeClient client = new TastyTradeClient();
        AuthenticationResponse response = client.Authenticate(request);
        assertNotNull(response.getData().getSessionToken());
    }
}
