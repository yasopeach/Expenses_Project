using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;
using MvcWorkspace.Services;

namespace MvcWorkspace.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            //IEnumerable<Expense> ExpenseList = _db.Expenses;

            //foreach (var exp in ExpenseList)
            //{
            //    exp.ExpenseCategory = _db.Categories.FirstOrDefault(e => e.Id == exp.ExpenseCategoryId);

            //}

            // EAGER LOADING
            IEnumerable<Expense> ExpenseList = _service.GetExpenses();
            return View(ExpenseList);
        }

        //GET- Add or Edit
        public IActionResult AddOrUpdate(int id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                CategoryDropDown = _service.CategorySelectListItems()

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
                expenseVM.Expense = _service.GetExpense(id);
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
                    _service.Add(expense);   
                else
                    _service.Update(expense);

                return RedirectToAction("Index");
            }
            return View(expense);
        }

        //Delete
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // GET : Expense By Category
        public IActionResult ExpensesByCategory(int id)
        {
            IEnumerable<Expense> expenseByCatList = _service.GetExpensesByCategory(id);

            ViewBag.catName = _service.GetCategoryName(id);

            ViewBag.totalAmount = GetTotal(expenseByCatList);
            return View(expenseByCatList);
        }

        private int GetTotal(IEnumerable<Expense> list)
        {
            int totalAmount = 0;
            foreach (var e in list)
            {
                totalAmount += e.Amount;
            }
            return totalAmount;

        }
    }
}