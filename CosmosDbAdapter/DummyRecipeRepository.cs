using Labdays.DigitalCookbook.Rest.Shared;
using rest.Shared;

namespace CosmosDbAdapter
{
    internal class DummyRecipeRepository : IRecipeRepository
    {
        public IEnumerable<Recipe> GetAllRecipes()
        {
            throw new NotImplementedException();
        }
    }
}
