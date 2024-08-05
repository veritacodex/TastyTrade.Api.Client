package common;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;
import java.util.logging.Logger;

public class PropertiesHelper {
    static Logger logger = Logger.getLogger(PropertiesHelper.class.getName());

    public static Properties getProperties(String filename) {
        try (InputStream input = PropertiesHelper.class.getClassLoader().getResourceAsStream(filename)) {
            Properties properties = new Properties();
            if (input == null) {
                System.out.println("Unable to find " + filename);
                return null;
            }
            properties.load(input);
            return properties;
        } catch (IOException ex) {
            logger.severe(ex.getMessage());
            return null;
        }
    }
}
