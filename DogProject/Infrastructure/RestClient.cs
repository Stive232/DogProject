namespace DogProject.Infrastructure;

/// <summary>
/// REST клиент.
/// </summary>
public class RestClient : IRestClient
{
    /// <summary>
    /// HTTP клиент.
    /// </summary>
    private  HttpClient _client;
    private static readonly object _lock = new object();

    public RestClient()
    {
        _client = new HttpClient();
    }

    public HttpClient GetRestClient()
    {
        lock(_lock)
        {
            if (_client == null)
            {
                _client = new HttpClient();
            }
                
            return _client;
        }
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        HttpResponseMessage response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return response;
    }
}
