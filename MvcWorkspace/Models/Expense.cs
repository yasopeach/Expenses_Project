using System.ComponentModel.DataAnnotations;

namespace MvcWorkspace.Models
{
    public class Expense
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name ="Expense Name")]
        public string ExpenseName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage="Yanlış Değer")]
        public int Amount { get; set; }

    }
}
