using Microsoft.AspNetCore.Mvc;

namespace MvcWorkspace.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
