using System.ComponentModel.DataAnnotations.Schema;

namespace FarmersAPI.Models;

public class Billing
{
    [Column("id")]
    public int Id { get; set; }

    [Column("collectionid")]
    public int CollectionId { get; set; }

    [Column("labourcharges")]
    public double LabourCharges { get; set; }

    [Column("totalamount")]
    public int TotalAmount { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }
}
