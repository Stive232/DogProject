namespace DogProject.Clients.Models;

public class DogsResponseModel
{
    /// <summary>
    /// Список ссылок на изображения.
    /// </summary>
    public List<string> Message { get; set; }

    /// <summary>
    /// Статус запроса.
    /// </summary>
    public string Status { get; set; }
}
