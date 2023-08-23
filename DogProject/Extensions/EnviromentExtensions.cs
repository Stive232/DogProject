namespace DogProject.Extensions;

public static class EnviromentExtensions
{
    public static void RegisterInteraction(this IServiceProvider serviceProvider)
    {
        IIntegration integration = serviceProvider.GetService<IIntegration>();
        integration.StartAsync().GetAwaiter().GetResult();
    }
}
