using Microsoft.AspNetCore.Mvc;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _db;

        public ExpenseController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> ExpenseList = _db.Expenses;

            return View(ExpenseList);
        }

        //GET- Add or Edit
        public IActionResult AddOrUpdate(int id)
        {
            if (id == 0)
                return View(new Expense());
            else
                return View(_db.Expenses.Find(id));
        }

        //POST : Add or Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Expense expense)
        {
            if (ModelState.IsValid) // Server side Validation
            {
                if (expense.Id == 0)
                {
                    _db.Add(expense);
                }
                else
                {
                    _db.Update(expense);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        //Delete
        public IActionResult Delete(int id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}