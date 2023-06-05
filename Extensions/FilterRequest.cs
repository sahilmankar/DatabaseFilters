using System.Text;
using Newtonsoft.Json;

namespace FarmersAPI.Extensions;

public class FilterRequest
{
    public List<EqualFilter>? EqualFilters { get; set; }
    public List<RangeFilter>? RangeFilters { get; set; }
    public List<DateRangeFilter>? DateRangeFilters { get; set; }
    public string? SortBy { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool SortAscending { get; set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append("EqualFilters: [");
        if (EqualFilters != null)
        {
            stringBuilder.Append(string.Join(", ", EqualFilters));
        }
        stringBuilder.Append("], ");

        stringBuilder.Append("RangeFilters: [");
        if (RangeFilters != null)
        {
            stringBuilder.Append(string.Join(", ", RangeFilters));
        }
        stringBuilder.Append("], ");

        stringBuilder.Append("DateRangeFilters: [");
        if (DateRangeFilters != null)
        {
            stringBuilder.Append(string.Join(", ", DateRangeFilters));
        }
        stringBuilder.Append("], ");

        stringBuilder.Append("SortBy: ");
        stringBuilder.Append(SortBy);
        stringBuilder.Append(", ");

        stringBuilder.Append("SortAscending: ");
        stringBuilder.Append(SortAscending);

        return stringBuilder.ToString();
    }
}

public class EqualFilter
{
    public string PropertyName { get; set; }
    public List<string>? PropertyValues { get; set; }

    public override string ToString()
    {
        string propertyValueString =
            PropertyValues != null ? string.Join(", ", PropertyValues) : "null";
        return $"PropertyName: {PropertyName}, PropertyValue: {propertyValueString}";
    }
}

public class RangeFilter
{
    public string PropertyName { get; set; }
    public int MinValue { get; set; }
    public int MaxValue { get; set; }

    public override string ToString()
    {
        return $"{{ PropertyName: {PropertyName}, MinValue: {MinValue}, MaxValue: {MaxValue} }}";
    }
}

public class DateRangeFilter
{
    public string PropertyName { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }

    public override string ToString()
    {
        return $"{{ PropertyName: {PropertyName}, FromDate: {FromDate}, ToDate: {ToDate} }}";
    }
}
