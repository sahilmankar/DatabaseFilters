using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models;

[Table("employees")]
public class Employee
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("dateofbirth")]
    public DateTime DateOfBirth { get; set; }

    [Column("departmentid")]
    public int DepartmentId { get; set; }

    [Column("salary")]
    public double Salary { get; set; }

    [Column("joiningdate")]
    public DateTime JoiningDate { get; set; }
}
