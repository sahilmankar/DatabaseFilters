
namespace FarmersAPI.Models;

public class PropertyCategorization
{
    public List<string>? EqualProperties { get; set; }
    public List<string>? RangeProperties { get; set; }
    public List<string>? DateProperties { get; set; }
}