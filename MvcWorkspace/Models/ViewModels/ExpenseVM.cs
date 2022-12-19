using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcWorkspace.Models.ViewModels
{
    public class ExpenseVM
    {
        public Expense Expense { get; set; }

        public IEnumerable<SelectListItem> CategoryDropDown { get; set; }

    }
}
