namespace rest.Client.Models
{
    public class RecipeModel
    {
        public Guid? Id {  get; set; }
        public string? Title { get; set; }
        public string? Instruction { get; set; }
        public IList<IngredientModel> Ingredients { get; set; }
        public byte[] Image { get; set; }

        public RecipeModel()
        {
            Ingredients = new List<IngredientModel>();
            Image = new byte[0];
        }   
    }
}
