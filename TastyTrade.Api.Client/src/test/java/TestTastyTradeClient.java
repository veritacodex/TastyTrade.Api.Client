import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;
import java.util.logging.Logger;

import static org.junit.jupiter.api.Assertions.assertEquals;

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
    public void testLucky() {
        assertEquals(8, TastyTradeClient.getLucky());
    }
}
