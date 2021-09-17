using CosmosDbAdapter.Models;
using Labdays.DigitalCookbook.Rest.Shared;
using Microsoft.Azure.Cosmos;
using rest.Shared;

namespace CosmosDbAdapter
{
    internal class CosmosDbRecipeRepository : IRecipeRepository
    {
        private readonly CosmosDbOptions _options;
        private readonly CosmosClient _client;

        public CosmosDbRecipeRepository(CosmosDbOptions options)
        {
            _options = options; 
            var clientOptions = new CosmosClientOptions { ApplicationName = options.ApplicationName };
            _client = new CosmosClient(options.EndpointUri, options.PrimaryKey, clientOptions);            
        }

        public async Task<Recipe> CreateAsync(Recipe newRecipe)
        {
            var dto = RecipeDto.From(newRecipe);
            // TODO (fi): find correct containerId
            var container = _client.GetContainer(_options.DatabaseId, _options.ContainerIds.Single());
            await container.CreateItemAsync(dto, new PartitionKey($"{dto.Id}"));
            return newRecipe;
        }

        public Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
