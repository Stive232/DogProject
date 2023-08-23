using DogProject.Clients.Models;

namespace DogProject.Clients;

public interface IDogClient
{
    Task<DogResponseModel> GetRandomDog();
    Task<DogsResponseModel> GetRandomDogByBreed(string breed);
}
