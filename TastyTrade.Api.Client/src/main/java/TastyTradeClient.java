import org.apache.hc.client5.http.classic.methods.HttpPost;
import org.apache.hc.client5.http.impl.classic.BasicHttpClientResponseHandler;
import org.apache.hc.client5.http.impl.classic.CloseableHttpClient;
import org.apache.hc.client5.http.impl.classic.CloseableHttpResponse;
import org.apache.hc.client5.http.impl.classic.HttpClients;
import org.apache.hc.core5.http.HttpHeaders;
import org.apache.hc.core5.http.io.entity.StringEntity;
import request.AuthenticationRequest;
import response.AuthenticationResponse;

import java.io.IOException;

public class TastyTradeClient {

    private final String API_ROOT = "https://api.cert.tastyworks.com";
    private final String SESSION_URI = "/sessions";
    private final CloseableHttpClient closeableHttpClient;

    public TastyTradeClient() {
        this.closeableHttpClient = HttpClients.createDefault();
    }

    public AuthenticationResponse Authenticate(AuthenticationRequest request) throws IOException {

        HttpPost httpPost = new HttpPost(API_ROOT + SESSION_URI);
        StringEntity entity = new StringEntity(AuthenticationRequest.toJsonString(request));
        httpPost.setEntity(entity);
        httpPost.setHeader(HttpHeaders.ACCEPT, "application/json");
        httpPost.setHeader(HttpHeaders.CONTENT_TYPE, "application/json");
        httpPost.setHeader(HttpHeaders.USER_AGENT, request.getUserAgent());
        try (CloseableHttpResponse response = closeableHttpClient.execute(httpPost)) {
            String responseString = new BasicHttpClientResponseHandler().handleResponse(response);
            return AuthenticationResponse.fromJsonString(responseString);
        }
    }
}
