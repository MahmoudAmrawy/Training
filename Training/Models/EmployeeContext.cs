using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Training.Models;

namespace Training.Models
{
    public class EmployeeContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EmployeeContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"data source =EL-AMRAWY\SQLEXPRESS; initial catalog=TrainingDB; integrated security=SSPI;");
        //}
    }
}
