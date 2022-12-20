using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;

namespace MvcWorkspace.Controllers
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
            //IEnumerable<Expense> ExpenseList = _db.Expenses;

            //foreach (var exp in ExpenseList)
            //{
            //    exp.ExpenseCategory = _db.Categories.FirstOrDefault(e => e.Id == exp.ExpenseCategoryId);

            //}

            // EAGER LOADING
            IEnumerable<Expense> ExpenseList = _db.Expenses.Include(u => u.ExpenseCategory);

            return View(ExpenseList);
        }

        //GET- Add or Edit
        public IActionResult AddOrUpdate(int id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                CategoryDropDown = _db.Categories.Select(i =>
                                    new SelectListItem
                                    {
                                        Text = i.CategoryName,
                                        Value = i.Id.ToString()
                                    })

        };



            //IEnumerable<SelectListItem> CategoryDropDown = _db.Categories.Select(i =>
            //new SelectListItem 
            //{ 
            //    Text=i.CategoryName, 
            //    Value = i.Id.ToString() 
            //});

            //ViewBag.CategoryDropDown = CategoryDropDown;



            if (id == 0) 
            { 
                return View(expenseVM);
            }
            else 
            { 
                expenseVM.Expense = _db.Expenses.Find(id);
                return View(expenseVM);
            }
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

        // GET : Expense By Category
        public IActionResult ExpensesByCategory(int id)
        {

            IEnumerable<Expense> expenseByCatList = _db.Expenses.Where(x => x.ExpenseCategoryId == id);

            int totalAmount = 0;
            foreach (var e in expenseByCatList)
            {
                totalAmount += e.Amount;
            }

            ViewBag.totalAmount = totalAmount;
            return View(expenseByCatList);
        }
    }
}