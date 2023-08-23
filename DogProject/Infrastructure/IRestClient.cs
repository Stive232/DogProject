namespace DogProject.Infrastructure;

public interface IRestClient
{
    Task<HttpResponseMessage> GetAsync(string url);
}
