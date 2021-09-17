using Labdays.DigitalCookbook.Rest.Shared;
using rest.Client.Models;

namespace rest.Server.ModelFactoryMethods
{
    public static class RecipeModelFactoryMethods
    {
        internal static Recipe ToRecipe(this RecipeModel recipeModel)
            => recipeModel.Id == null
            ? Recipe.CreateNew(recipeModel.Title, recipeModel.Instruction, recipeModel.Ingredients.Select(x => x.ToIngredient()))
            : Recipe.Create(recipeModel.Id.Value, recipeModel.Title, recipeModel.Instruction, recipeModel.Ingredients.Select(x => x.ToIngredient()));
    }
}
