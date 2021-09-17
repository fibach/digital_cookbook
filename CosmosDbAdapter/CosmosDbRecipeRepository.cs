using CosmosDbAdapter.Models;
using Labdays.DigitalCookbook.Rest.Shared;
using Microsoft.Azure.Cosmos;
using rest.Shared;
using System.Net;

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
            await Container.CreateItemAsync(dto, new PartitionKey(dto.Id));
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

        public async Task<Recipe> GetByIdAsync(Guid recipeId)
        {
            try
            {
                var respnse = await Container.ReadItemAsync<RecipeDto>($"{recipeId}", new PartitionKey($"{recipeId}"));
                var recipe = respnse.Resource.ToRecipe();
                return recipe;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"No recipe with Id {recipeId} was found");
            }
        }

        public async Task<Recipe> UpdateAsync(Recipe changedRecipe)
        {
            var dto = RecipeDto.From(changedRecipe);
            var response = await Container.ReplaceItemAsync(dto, dto.Id, new PartitionKey(dto.Id));
            var changedDto = response.Resource;
            return changedDto.ToRecipe();
        }

        public async Task DeleteAsync(Guid recipeId)
        {
            await Container.DeleteItemAsync<RecipeDto>($"{recipeId}", new PartitionKey($"{recipeId}"));
        }

        private Container Container => _client.GetContainer(_options.DatabaseId, _options.ContainerIds.Single(x => x ==  ContainerId));
    }
}
