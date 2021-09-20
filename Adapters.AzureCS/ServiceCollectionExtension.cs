using Adapters.AzureCS;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAzureCS(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IComputerVisionOcrRepository, ComputerVisionOCR>();
        }
    }
}
