using Labdays.DigitalCookbook.Rest.Shared;

namespace rest.Server.Models
{
    public class RecipeModel
    {
        public Guid? Id {  get; set; }
        public string? Title { get; set; }
        public string? Instruction { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public byte[] Image { get; set; }

        public RecipeModel()
        {
            Ingredients = new List<Ingredient>();
            Image = new byte[0];
        }   
    }
}
