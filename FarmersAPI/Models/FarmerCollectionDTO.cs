namespace FarmersAPI.Models;

public class FarmerCollectionDTO
{
    public int CollectionId { get; set; }
    public string? Crop { get; set; }
    public string? ContainerType { get; set; }

    public int Quantity { get; set; }

    public string? Grade { get; set; }

    public double TotalWeight { get; set; }

    public double TareWeight { get; set; }

    public double NetWeight { get; set; }

    public double RatePerKg { get; set; }

    public double Amount
    {
        get { return this.NetWeight * this.RatePerKg; }
    }
    public DateTime CollectionDate { get; set; }
    public int BillId { get; set; }

    public double LabourCharges { get; set; }

    public int TotalAmount { get; set; }

    public DateTime BillingDate { get; set; }
}
