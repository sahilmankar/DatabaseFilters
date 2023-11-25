using EmployeeAPI.Extensions;
using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories.Interfaces;

public interface IEmployeeRepository
{
    PagedList<EmployeeDetail> GetEmployees(FilterRequest request, int pageNumber);
    IEnumerable<string> GetDepartmentNames(string? searchString = null);
    IEnumerable<string> GetEmployeeNames(string? searchString = null);
}
