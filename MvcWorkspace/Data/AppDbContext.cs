using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Models;

namespace MvcWorkspace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseCategory> Categories { get; set; }
    }

    //DbSet'ler  
}
