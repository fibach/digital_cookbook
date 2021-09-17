using Labdays.DigitalCookbook.Rest.Shared;

namespace CosmosDbAdapter.Models
{
    internal class IngredientDto
    {
        public string? Name { get; set; }
        public double Amount { get; set; }
        public string? Unit { get; set; }

        internal static IngredientDto From(Ingredient ingredient)
            => new IngredientDto { Name = ingredient.Name, Amount = ingredient.Amount, Unit = ingredient.Unit.ToString() };
    }
}
