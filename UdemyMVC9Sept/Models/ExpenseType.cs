using System.ComponentModel.DataAnnotations;

namespace UdemyMVC9Sept.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
