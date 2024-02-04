using EmployeeAPI.Models;
using EmployeeAPI.Repositories.Interfaces;
using EmployeeAPI.Repositories.Contexts;
using EmployeeAPI.Extensions;
using System.Linq.Dynamic.Core;

namespace EmployeeAPI.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeContext _context;

    public EmployeeRepository(EmployeeContext context)
    {
        _context = context;
    }

    public IEnumerable<string> GetDepartmentNames(string? searchString = null)
    {
        searchString = searchString?.Trim();

        if (string.IsNullOrEmpty(searchString))
        {
            return _context.Departments.Select(dept => dept.Name).Take(5).AsEnumerable();
        }

        return _context.Departments
            .Where(dept => dept.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            .Select(d => d.Name)
            .OrderByDescending(name => name.StartsWith(searchString,StringComparison.OrdinalIgnoreCase))
            .Take(5)
            .AsEnumerable();
    }

    public IEnumerable<string> GetEmployeeNames(string? searchString = null)
    {
        searchString = searchString?.Trim();

        if (string.IsNullOrEmpty(searchString))
        {
            return _context.Employees.Select(emp => emp.Name).Take(5).AsEnumerable();
        }

        return _context.Employees
            .Where(emp => emp.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            .Select(emp => emp.Name)
            .OrderByDescending(name => name.StartsWith(searchString,StringComparison.OrdinalIgnoreCase))
            .Take(5)
            .AsEnumerable();
    }

    public PagedList<EmployeeDetail> GetEmployees(FilterRequest request, int pageNumber)
    {
        IQueryable<EmployeeDetail>? query =
            from emp in _context.Employees
            join dept in _context.Departments on emp.DepartmentId equals dept.Id
            select new EmployeeDetail()
            {
                Id = emp.Id,
                Name = emp.Name,
                DepartmentName = dept.Name,
                DateOfBirth = emp.DateOfBirth,
                Salary = emp.Salary,
                JoiningDate = emp.JoiningDate,
                DepartmentId = emp.DepartmentId
            };

        query = query.ApplyFilters(request);
        return PagedList<EmployeeDetail>.ToPagedList(query, pageNumber);
    }
}
