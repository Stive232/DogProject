namespace DogProject.Extensions;

/// <summary> 
/// Предоставляет методы расширения для <see cref="IApplicationBuilder" />. 
/// </summary> 
public static class ApplicationBuilderExtension
{
    /// <summary> 
    /// Выполняет регистрацию сервиса взаимодействия с внешними системами в жизненном цикле приложения. 
    /// </summary> 
    public static IApplicationBuilder UseInteraction(this IApplicationBuilder builder)
    {
        builder.ApplicationServices.RegisterInteraction();
        return builder;
    }
}

