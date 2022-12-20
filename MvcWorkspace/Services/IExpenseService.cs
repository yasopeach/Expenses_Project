using Microsoft.AspNetCore.Mvc.Rendering;
using MvcWorkspace.Models;

namespace MvcWorkspace.Services
{
    public interface IExpenseService
    {
        //Liste Expense'ler
        IEnumerable<Expense> GetExpenses();

        //Tek bir expense
        Expense GetExpense(int id);
        
        //Ekle Expense
        void Add(Expense expense);  
        
        //Güncelle Expense
        void Update(Expense expense);   
        
        //Sil Expense
        bool Delete(int id);
        
        //Kategori Adıyla Expense'ler
        IEnumerable<Expense> GetExpensesWithCategoryName();
        
        //Bir Kategorideki Expense'ler
        IEnumerable<Expense> GetExpensesByCategory(int id);

        //Kategori Listesi Select Item olarak
        IEnumerable<SelectListItem> CategorySelectListItems();

        //Kategori Adı Getir
        string GetCategoryName(int id);
    
    }
}
