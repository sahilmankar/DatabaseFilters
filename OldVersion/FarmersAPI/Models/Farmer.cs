using System.ComponentModel.DataAnnotations.Schema;
namespace FarmersAPI.Models;
public class Farmer
{
    [Column("id")]
    public int Id { get; set; }

    [Column("firstname")]
    public string? FirstName { get; set; }

     [Column("lastname")]
    public string? LastName { get; set; }
    
    [Column("location")]
    public string? Location { get; set; }

     [Column("contactnumber")]
    public string? ContactNumber { get; set; }

}