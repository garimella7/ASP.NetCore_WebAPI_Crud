using EmployeesCrudAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCrudAPI.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
