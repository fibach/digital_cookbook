namespace Labdays.DigitalCookbook.Rest.Shared
{
    public class Ingredient
    {
        public string? Name { get; set; }
        public double Amount { get; set; }
        public Unit Unit {get; set;}

        public static Ingredient Create(string name, double amount, Unit unit)
            => new Ingredient { Name = name, Amount = amount, Unit = unit };
    }
}