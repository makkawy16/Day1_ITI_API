using CQRS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions) { }
    }
}
