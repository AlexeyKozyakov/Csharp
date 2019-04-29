using Microsoft.EntityFrameworkCore;

namespace lab4Web.Models
{
    public class DataContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        
    }
}