using Microsoft.EntityFrameworkCore;

namespace MvcWorkspace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }

    //DbSet'ler
}
