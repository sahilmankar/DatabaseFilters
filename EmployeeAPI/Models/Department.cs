using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models;

[Table("departments")]
public class Department
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }
}
