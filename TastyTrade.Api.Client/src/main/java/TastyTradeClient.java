import org.apache.hc.client5.http.classic.methods.HttpPost;
import org.apache.hc.client5.http.impl.classic.CloseableHttpResponse;
import org.apache.hc.core5.http.HttpHeaders;
import org.apache.hc.core5.http.io.entity.StringEntity;

import java.io.IOException;

public class TastyTradeClient {

//    public void Authenticate(String username, String password) throws IOException, InterruptedException {
//
//        HttpPost httpPost = new HttpPost(baseUri + SESSION_URI);
//        AuthenticationRequest request = new AuthenticationRequest();
//        request.setIdentifier(username);
//        request.setPassword(password);
//        StringEntity entity = new StringEntity(AuthenticationRequest.toJsonString(request));
//        httpPost.setEntity(entity);
//        httpPost.setHeader(HttpHeaders.ACCEPT, "application/json");
//        httpPost.setHeader(HttpHeaders.CONTENT_TYPE, "application/json");
//        httpPost.setHeader("Version", "3");
//        httpPost.setHeader("X-IG-API-KEY", apiKey);
//        try (CloseableHttpResponse response = closeableHttpClient.execute(httpPost)) {
//            String responseString = new BasicResponseHandler().handleResponse(response);
//            AuthenticationResponse authResponse = AuthenticationResponse.fromJsonString(responseString);
//            authResponse.setDate(new Date(System.currentTimeMillis()));
//            authenticationResponse = authResponse;
//        }
//    }

    public static int getLucky() {
        return 7;
    }
}
