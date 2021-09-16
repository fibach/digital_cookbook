namespace Labdays.DigitalCookbook.Rest.Shared
{    
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Instruction { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public byte[] Image { get; set; }
    }
}