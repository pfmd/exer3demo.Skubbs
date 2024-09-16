using Exer3.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Exer3.Api.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
