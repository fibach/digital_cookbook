using Labdays.DigitalCookbook.Rest.Shared;

namespace rest.Shared
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe> CreateAsync(Recipe newRecipe);
    }
}
