using System.ComponentModel.DataAnnotations;

namespace MvcWorkspace.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
