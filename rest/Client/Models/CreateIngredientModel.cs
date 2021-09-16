namespace rest.Server.Models
{
    public class CreateIngredientModel
    {
        public string? Name { get; set; }
        public double Amount { get; set; }
        public UnitDto Unit { get; set; }


        public enum UnitDto
        {
            mg,
            g,
            El,
            ml
        }
    }
}
