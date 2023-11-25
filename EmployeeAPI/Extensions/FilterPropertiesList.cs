namespace EmployeeAPI.Extensions;

public class FilterPropertiesList
{
    public required List<string> EqualProperties { get; set; }
    public required List<string> RangeProperties { get; set; }
    public required List<string> DateRangeProperties { get; set; }
    public required List<string> AllProperties { get; set; }
}
