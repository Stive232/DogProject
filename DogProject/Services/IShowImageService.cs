namespace DogProject.Services;

/// <summary>
/// Абстракция над сервисом вывода изображения.
/// </summary>
public interface IShowImageService
{
    /// <summary>
    /// Предоставляет визуализацию изображения.
    /// </summary>
    /// <param name="path"></param>
    void Show(string path);
}