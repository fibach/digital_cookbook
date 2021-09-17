using Labdays.DigitalCookbook.Rest.Shared;

namespace rest.Shared
{
    public interface IRecipeRepository
    {
        public Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        public Task<Recipe> CreateAsync(Recipe newRecipe);
    }
}
