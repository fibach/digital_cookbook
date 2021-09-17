using Labdays.DigitalCookbook.Rest.Shared;
using rest.Client.Models;

namespace rest.Server.ModelFactoryMethods
{
    public static class IngredientModelFactoryMethods
    {
        public static Ingredient ToIngredient(this IngredientModel @model)
        {
            return new Ingredient
            {
                Name = @model.Name,
                Amount = @model.Amount,
                Unit = Enum.Parse<Unit>(@model.Unit.ToString())
            };
        }
    }
}
