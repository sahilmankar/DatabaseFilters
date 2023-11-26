using System.ComponentModel.DataAnnotations.Schema;

namespace FarmersAPI.Models;

public class Collection
{
    [Column("id")]
    public int Id { get; set; }

    [Column("farmerid")]
    public int FarmerId { get; set; }

    [Column("cropid")]
    public int CropId { get; set; }

    [Column("containertype")]
    public string? ContainerType { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("grade")]
    public string? Grade { get; set; }

    [Column("totalweight")]
    public double TotalWeight { get; set; }

    [Column("tareweight")]
    public double TareWeight { get; set; }

    [Column("netweight")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double NetWeight { get; set; }

    [Column("rateperkg")]
    public double RatePerKg { get; set; }

    public double Amount
    {
        get { return this.NetWeight * this.RatePerKg; }
    }

    [Column("date")]
    public DateTime Date { get; set; }
}
