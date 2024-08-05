package client;

import org.apache.hc.client5.http.async.methods.SimpleHttpRequest;
import org.apache.hc.client5.http.async.methods.SimpleHttpResponse;
import org.apache.hc.client5.http.async.methods.SimpleRequestBuilder;
import org.apache.hc.client5.http.impl.async.CloseableHttpAsyncClient;
import org.apache.hc.client5.http.impl.async.HttpAsyncClients;
import org.apache.hc.core5.http.ContentType;
import org.apache.hc.core5.http.HttpHeaders;
import request.AuthenticationRequest;
import response.*;

import java.io.IOException;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;

public class TastyTradeClient {

    private static final String APIROOT = "https://api.cert.tastyworks.com";
    private AuthenticationResponse authResponse;
    private String userAgent;

    public AuthenticationResponse authenticate(AuthenticationRequest request) throws IOException, ExecutionException, InterruptedException {
        userAgent = request.getUserAgent();
        CloseableHttpAsyncClient client = HttpAsyncClients.createDefault();
        try (client) {
            client.start();
            SimpleHttpRequest postRequest = SimpleRequestBuilder.post(APIROOT + "/sessions")
                    .setHeader(HttpHeaders.USER_AGENT, userAgent)
                    .setBody(AuthenticationRequest.toJsonString(request), ContentType.APPLICATION_JSON)
                    .build();
            Future<SimpleHttpResponse> future = client.execute(postRequest, null);
            SimpleHttpResponse response = future.get();
            authResponse = AuthenticationResponse.fromJsonString(response.getBodyText());
            return authResponse;
        }
    }

    public String get(String uri) throws IOException, ExecutionException, InterruptedException {
        CloseableHttpAsyncClient client = HttpAsyncClients.createDefault();
        try (client) {
            client.start();
            SimpleHttpRequest getRequest = SimpleRequestBuilder.get(uri)
                    .setHeader(HttpHeaders.USER_AGENT, userAgent)
                    .setHeader(HttpHeaders.AUTHORIZATION, authResponse.getData().getSessionToken())
                    .setHeader(HttpHeaders.ACCEPT, ContentType.APPLICATION_JSON.toString())
                    .build();
            Future<SimpleHttpResponse> future = client.execute(getRequest, null);
            SimpleHttpResponse response = future.get();
            return response.getBodyText();
        }
    }

    public CustomerResponse getCustomer() throws IOException, ExecutionException, InterruptedException {
        String response = get(APIROOT + "/customers/me");
        return CustomerResponse.fromJsonString(response);
    }

    public AccountsResponse getAccounts(String customerId) throws IOException, ExecutionException, InterruptedException {
        String response = get(APIROOT + "/customers/" + customerId + "/accounts");
        return AccountsResponse.fromJsonString(response);
    }

    public FuturesResponse getAllFutures() throws IOException, ExecutionException, InterruptedException {
        String response = get(APIROOT + "/instruments/futures/");
        return FuturesResponse.fromJsonString(response);
    }

    public FuturesSingleResponse getFutures(String symbol) throws IOException, ExecutionException, InterruptedException {
        String response = get(APIROOT + "/instruments/futures/" + symbol);
        return FuturesSingleResponse.fromJsonString(response);
    }

    public APIQuoteTokensResponse getApiQuoteTokens() throws IOException, ExecutionException, InterruptedException {
        String response = get(APIROOT + "/api-quote-tokens");
        return APIQuoteTokensResponse.fromJsonString(response);
    }
}