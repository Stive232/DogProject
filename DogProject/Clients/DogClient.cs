using DogProject.Clients.Models;
using DogProject.Infrastructure;
using Newtonsoft.Json;

namespace DogProject.Clients;

public class DogClient : IDogClient
{
    private readonly IRestClient _client;
    private const string baseAddress = "https://dog.ceo/";
    private const string randomDogApiPath = "api/breeds/image/random";
    private const string randomDogsByBreedApiPath = "api/breed/{0}/images/random/{1}"; //Todo: пути нужно вынести в конфигурационный файл.
    private const int countImages = 3;

    public DogClient(IRestClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Предоставляет случайное изображение собаки.
    /// </summary>
    /// <returns></returns>
    public async Task<DogResponseModel> GetRandomDog()
    {
        var response = await _client.GetAsync(baseAddress + randomDogApiPath);
        string result = await response.Content.ReadAsStringAsync();
        DogResponseModel dog = JsonConvert.DeserializeObject<DogResponseModel>(result);

        return dog;
    }

    /// <summary>
    /// Предоставляет случайные изображения определенной породы.
    /// </summary>
    /// <param name="breed"></param>
    /// <returns></returns>
    public async Task<DogsResponseModel> GetRandomDogByBreed(string breed)
    {
        string a = string.Format(randomDogsByBreedApiPath, breed, countImages);
        var response = await _client.GetAsync(baseAddress + string.Format(randomDogsByBreedApiPath, breed, countImages));
        string result = await response.Content.ReadAsStringAsync();
        DogsResponseModel dogs = JsonConvert.DeserializeObject<DogsResponseModel>(result);

        return dogs;
    }
}
