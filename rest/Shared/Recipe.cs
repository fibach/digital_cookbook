namespace Labdays.DigitalCookbook.Rest.Shared
{    
    public class Recipe
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Instruction { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public byte[] Image { get; set; }

        public Recipe()
        {
            Id = Guid.NewGuid();
            Ingredients = new List<Ingredient>();
            Image = new byte[0];
        }

        public static Recipe CreateNew(string? title, string? instruction, IEnumerable<Ingredient> ingredients)
            => new Recipe { Title = title, Instruction = instruction, Ingredients = ingredients };

        public static Recipe Create(Guid id, string? title, string? instruction, IEnumerable<Ingredient> ingredients)
            => new Recipe {Id = id, Title = title, Instruction = instruction, Ingredients = ingredients };
    }
}