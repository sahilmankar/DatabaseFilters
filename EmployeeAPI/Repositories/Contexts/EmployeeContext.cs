using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EmployeeAPI.Repositories.Contexts;

public class EmployeeContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    public EmployeeContext(DbContextOptions options)
        : base(options)
    {
        Employees = Set<Employee>();
        Departments = Set<Department>();
    }
}
