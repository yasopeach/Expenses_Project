using System.ComponentModel.DataAnnotations;

namespace MvcWorkspace.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
