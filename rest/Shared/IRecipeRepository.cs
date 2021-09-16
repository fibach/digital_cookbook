using Labdays.DigitalCookbook.Rest.Shared;

namespace rest.Shared
{
    public interface IRecipeRepository
    {
        public IEnumerable<Recipe> GetAllRecipes();
    }
}
