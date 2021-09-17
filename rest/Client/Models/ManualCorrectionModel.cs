using System.ComponentModel.DataAnnotations;

namespace rest.Client.Models
{
    public class ManualCorrectionModel
    {
        public string? Ingredients { get; set; }
        public string? Instruction { get; set; }

        [Required]
        public string? Title { get; set; }

        public bool IsEmpty => Ingredients == null && Instruction == null && Title == null;
    }
}
