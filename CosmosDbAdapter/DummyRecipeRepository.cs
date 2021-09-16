using Labdays.DigitalCookbook.Rest.Shared;
using rest.Shared;

namespace CosmosDbAdapter
{
    internal class DummyRecipeRepository : IRecipeRepository
    {
        private readonly ICollection<Recipe> _recipes;

        public DummyRecipeRepository()
        {
            _recipes = new List<Recipe>
            {
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
                RecipeFactory,
            };
        }

        public Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return Task.FromResult<IEnumerable<Recipe>>(_recipes);
        }

        private static Recipe RecipeFactory => Recipe.CreateNew
        (              
            RandomString(20),
            RandomString(200),
            new[]
            {
                IngredientFactory,
                IngredientFactory
            }
        );

        private static Ingredient IngredientFactory => new Ingredient
        {
            Amount= new Random().Next(100),
            Unit = Unit.g,
            Name = RandomString(20)
        };

        private static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Task<Recipe> CreateAsync(Recipe newRecipe)
        {
            _recipes.Add(newRecipe);            
            return Task.FromResult(newRecipe);
        }
    }
}
