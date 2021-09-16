using Labdays.DigitalCookbook.Rest.Shared;
using Microsoft.Azure.Cosmos;
using rest.Shared;

namespace CosmosDbAdapter
{
    internal class CosmosDbRecipeRepository : IRecipeRepository
    {
        private readonly CosmosClient _client;

        public CosmosDbRecipeRepository(CosmosDbOptions options)
        {
            var clientOptions = new CosmosClientOptions { ApplicationName = options.ApplicationName };
            _client = new CosmosClient(options.EndpointUri, options.PrimaryKey, clientOptions);
        }

        public Task<Recipe> CreateAsync(Recipe newRecipe)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
