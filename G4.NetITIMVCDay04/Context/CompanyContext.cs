using G4.NetITIMVCDay04.Models;
using Microsoft.EntityFrameworkCore;

namespace G4.NetITIMVCDay04.Context
{
    public class CompanyContext : DbContext
    {
        /*---------------------------------------------------------*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=G4.NetITIMVCDay04;Trusted_Connection=True;Encrypt=false");
        }
        /*---------------------------------------------------------*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*-----------------------------------------------------*/
            // Seading
            var _Departments = new List<Department>
            {
                new Department { Id = 1, DeptName = "HR" },
                new Department { Id = 2, DeptName = "PR" },
                new Department { Id = 3, DeptName = "Social Media" },
                new Department { Id = 4, DeptName = "Finance" }
            };
            /*-----------------------------------------------------*/
            var _Employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Ramy", Age = 22, Salary = 1234, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Mai", Age = 32, Salary = 2234, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Ali", Age = 42, Salary = 3234, DepartmentId = 3 },
                new Employee { Id = 4, Name = "Omar", Age = 52, Salary = 4234, DepartmentId = 4 },
                new Employee { Id = 5, Name = "Mostafa", Age = 28, Salary = 5234, DepartmentId = 1 },
                new Employee { Id = 6, Name = "Ahmed", Age = 38, Salary = 6234, DepartmentId = 2 },
                new Employee { Id = 7, Name = "Sara", Age = 48, Salary = 7234, DepartmentId = 3 },
                new Employee { Id = 8, Name = "Osama", Age = 26, Salary = 8234, DepartmentId = 4 },
                new Employee { Id = 9, Name = "Mohamed", Age = 36, Salary = 9234, DepartmentId = 1 },
                new Employee { Id = 10, Name = "Nour", Age = 46, Salary = 10234, DepartmentId = 2 },
                new Employee { Id = 11, Name = "Mohamed", Age = 46, Salary = 10234, DepartmentId = 3 },
                new Employee { Id = 12, Name = "Nour", Age = 46, Salary = 10234, DepartmentId = 4 }
            };
            /*-----------------------------------------------------*/
            modelBuilder.Entity<Department>().HasData(_Departments);
            modelBuilder.Entity<Employee>().HasData(_Employees);
            /*-----------------------------------------------------*/
        }
        /*---------------------------------------------------------*/
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        /*---------------------------------------------------------*/
    }
}
