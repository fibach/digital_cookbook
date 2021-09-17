using Adapters.AzureCS;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<NewRecipeCommand>()
                .AddTransient<IComputerVisionOcrRepository, ComputerVisionOCR>();
        }
    }
}
