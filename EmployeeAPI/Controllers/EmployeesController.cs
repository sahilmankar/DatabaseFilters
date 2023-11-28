using EmployeeAPI.Extensions;
using EmployeeAPI.Models;
using EmployeeAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("/api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _repository;

    public EmployeesController(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IEnumerable<EmployeeDetail> GetEmployees(
        FilterRequest request,
        [FromQuery] int pageNumber
    )
    {
        var employees = _repository.GetEmployees(request, pageNumber);
        Response.AddPaginationHeader(employees);
        return employees;
    }

    [HttpGet("proprerties")]
    public FilterPropertiesList GetAllEmployeeProperties()
    {
        return PropertyHelper.GetAllProperties<EmployeeDetail>();
    }

    [HttpGet("departments/names")]
    public IEnumerable<string> GetDepartmentNames([FromQuery] string? searchString = null)
    {
        return _repository.GetDepartmentNames(searchString);
    }

    [HttpGet("names")]
    public IEnumerable<string> GetEmployeeNames([FromQuery] string? searchString = null)
    {
        return _repository.GetEmployeeNames(searchString);
    }
}
