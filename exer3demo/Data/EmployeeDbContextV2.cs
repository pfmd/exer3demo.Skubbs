using exer3demo.Models;
using Microsoft.EntityFrameworkCore;

namespace exer3demo.Data
{
    public class EmployeeDbContextV2 :DbContext
    {
        public EmployeeDbContextV2(DbContextOptions<EmployeeDbContextV2> options):base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
