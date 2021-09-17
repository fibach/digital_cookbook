using Labdays.DigitalCookbook.Rest.Shared;
using Newtonsoft.Json;

namespace CosmosDbAdapter.Models
{
    internal class RecipeDto
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Instruction { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }

        public RecipeDto()
        {
            Ingredients = new List<IngredientDto>();
        }

        public static RecipeDto From(Recipe recipe)
        {
            return new RecipeDto
            {
                Id = $"{recipe.Id}",
                Title = recipe.Title,
                Instruction = recipe.Instruction,
                Ingredients = recipe.Ingredients.Select(x => IngredientDto.From(x))
            };
        }

        public Recipe ToRecipe() => Recipe.Create(Guid.Parse(Id ?? string.Empty), Title, Instruction, 
                Ingredients.Select(x => Ingredient.Create(x.Name ?? "NaN", x.Amount, Enum.Parse<Unit>(x.Unit ?? string.Empty))));
    }
}
