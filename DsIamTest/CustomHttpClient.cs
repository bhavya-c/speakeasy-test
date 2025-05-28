using Docusign.IAM.SDK.Utils;

public class CustomHttpClient : ISpeakeasyHttpClient
{
    protected readonly HttpClient httpClient;

    public CustomHttpClient()
    {
        httpClient = new System.Net.Http.HttpClient();
    }

    public virtual async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
    {
        // custom log
        Console.WriteLine($"[CUSTOM_HTTP] {request.Method} {request.RequestUri}");
        var response = await httpClient.SendAsync(request);
        Console.WriteLine($"[CUSTOM_HTTP] Response: {(int)response.StatusCode} {response.ReasonPhrase}");

        return response;
    }

    public virtual async Task<HttpRequestMessage> CloneAsync(HttpRequestMessage request)
    {
        HttpRequestMessage clone = new HttpRequestMessage(request.Method, request.RequestUri);

        if (request.Content != null)
        {
            clone.Content = new ByteArrayContent(await request.Content.ReadAsByteArrayAsync());
            if (request.Content.Headers != null)
            {
                foreach (var h in request.Content.Headers)
                {
                    clone.Content.Headers.Add(h.Key, h.Value);
                }
            }
        }

        foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
        {
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        foreach (KeyValuePair<string, object?> prop in request.Options)
        {
            clone.Options.TryAdd(prop.Key, prop.Value);
        }

        return clone;
    }
}
