using Labdays.DigitalCookbook.Rest.Shared;
using rest.Shared;

namespace CosmosDbAdapter
{
    internal class DummyRecipeRepository : IRecipeRepository
    {        
        public IEnumerable<Recipe> GetAllRecipes()
        {
            return new[]
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

        private static Recipe RecipeFactory => new Recipe
        {
            Id = Guid.NewGuid(),
            Title = RandomString(20),
            Instruction = RandomString(200),
            Ingredients = new[]
            {
                IngredientFactory,
                IngredientFactory
            }
        };

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

    }
}
