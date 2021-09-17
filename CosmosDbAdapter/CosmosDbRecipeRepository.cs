using CosmosDbAdapter.Models;
using Labdays.DigitalCookbook.Rest.Shared;
using Microsoft.Azure.Cosmos;
using rest.Shared;

namespace CosmosDbAdapter
{
    internal class CosmosDbRecipeRepository : IRecipeRepository
    {
        private const string ContainerId = "Recipes";
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
            var container = Container;
            await container.CreateItemAsync(dto, new PartitionKey($"{dto.Id}"));
            return newRecipe;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            var sqlQueryText = "SELECT * FROM c";
            var queryDefinition = new QueryDefinition(sqlQueryText);
            var queryResultSetIterator = Container.GetItemQueryIterator<RecipeDto>(queryDefinition);
            var recipes = new List<Recipe>();

            while (queryResultSetIterator.HasMoreResults)
            {
                var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (var recipeDto in currentResultSet)
                {
                    recipes.Add(recipeDto.ToRecipe());
                }
            }
            return recipes;
        }

        public Task<Recipe> GetById(Guid recipeId)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> UpdateAsync(Recipe changedRecipe)
        {
            throw new NotImplementedException();
        }

        private Container Container => _client.GetContainer(_options.DatabaseId, _options.ContainerIds.Single(x => x ==  ContainerId));
    }
}
