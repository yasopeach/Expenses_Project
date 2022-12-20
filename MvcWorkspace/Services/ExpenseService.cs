using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;

namespace MvcWorkspace.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly AppDbContext _db;

        public ExpenseService(AppDbContext db)
        {
            _db = db;
        }
        public void Add(Expense expense)
        {
            _db.Add(expense);
            _db.SaveChanges();
        }

        public IEnumerable<SelectListItem> CategorySelectListItems()
        {
            return _db.Categories.Select(i =>
                                    new SelectListItem
                                    {
                                        Text = i.CategoryName,
                                        Value = i.Id.ToString()
                                    });
    }

        public bool Delete(int id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return false;
            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return true;
        }

        public Expense GetExpense(int id)
        {
            return _db.Expenses.Find(id);
            
        }

        public IEnumerable<Expense> GetExpenses()
        {
            return _db.Expenses.Include(u => u.ExpenseCategory);
        }

        public IEnumerable<Expense> GetExpensesByCategory(int catId)
        {
            return _db.Expenses.Where(x => x.ExpenseCategoryId == catId);
        }

        public IEnumerable<Expense> GetExpensesWithCategory()
        {
            return _db.Expenses.Include(u => u.ExpenseCategory);
        }

        public void Update(Expense expense)
        {

            _db.Update(expense);
            _db.SaveChanges();

        }

        public string GetCategoryName(int id)
        {
            return _db.Categories.Find(id).CategoryName;
        }

        public IEnumerable<Expense> GetExpensesWithCategoryName()
        {
            throw new NotImplementedException();
        }
    }
}
