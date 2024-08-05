import org.apache.hc.client5.http.async.methods.SimpleHttpRequest;
import org.apache.hc.client5.http.async.methods.SimpleHttpResponse;
import org.apache.hc.client5.http.async.methods.SimpleRequestBuilder;
import org.apache.hc.client5.http.classic.methods.HttpPost;
import org.apache.hc.client5.http.impl.async.CloseableHttpAsyncClient;
import org.apache.hc.client5.http.impl.async.HttpAsyncClients;
import org.apache.hc.core5.http.ContentType;
import org.apache.hc.core5.http.HttpHeaders;
import org.apache.hc.core5.http.io.entity.StringEntity;
import request.AuthenticationRequest;
import response.AuthenticationResponse;

import java.io.IOException;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;

public class TastyTradeClient {

    private final String API_ROOT = "https://api.cert.tastyworks.com";
    private final String SESSION_URI = "/sessions";

    public AuthenticationResponse Authenticate(AuthenticationRequest request) throws IOException, ExecutionException, InterruptedException {
        CloseableHttpAsyncClient client = HttpAsyncClients.createDefault();
        try (client) {
            client.start();
            SimpleHttpRequest postRequest = SimpleRequestBuilder.post(API_ROOT + SESSION_URI)
                    .setBody(AuthenticationRequest.toJsonString(request), ContentType.APPLICATION_JSON)
                    .build();
            Future<SimpleHttpResponse> future = client.execute(postRequest, null);
            SimpleHttpResponse response = future.get();
            return AuthenticationResponse.fromJsonString(response.getBodyText());
        }
    }
}
