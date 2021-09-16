using Microsoft.Extensions.DependencyInjection;
using rest.Shared;

namespace CosmosDbAdapter
{
    public  static class ServiceCollectionSetup
    {
        public static IServiceCollection AddRecipeRepository(this IServiceCollection @service)
        {
            return service.AddSingleton<IRecipeRepository, DummyRecipeRepository>();
        }
    }
}
