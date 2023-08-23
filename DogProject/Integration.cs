using DogProject.Clients;
using DogProject.Services;
using DogProject.Clients.Models;

namespace DogProject;

public class Integration : IIntegration
{
    private readonly IDogClient _dogClient;
    private readonly IShowImageService _presentorService;

    public Integration(IDogClient dogClient, IShowImageService presentorService)
    {
        _dogClient = dogClient;
        _presentorService = presentorService;
    }

    /// <summary>
    /// Запуск интеграции.
    /// </summary>
    /// <returns></returns>
    public async Task StartAsync()
    {
        DogResponseModel dog = await _dogClient.GetRandomDog();
        string breed = GetBreedFromUrl(dog.Message);
        DogsResponseModel dogs = await _dogClient.GetRandomDogByBreed(breed);

        List<string> images = new();
        images.Add(dog.Message);
        images.AddRange(dogs.Message);

        Show(images);
    }

    private void Show(List<string> images)
    {
        foreach (string image in images)
        {
            _presentorService.Show(image);
        }
    }

    /// <summary>
    /// Предоставляет породу из url.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private string GetBreedFromUrl(string url)
    {
        return url.Split('/')[4].Split('-')[0];
    }
}
