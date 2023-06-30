using System.Text;
using Newtonsoft.Json;

namespace FarmersAPI.Extensions;

public class FilterRequest
{
    public List<EqualFilter>? EqualFilters { get; set; }
    public List<RangeFilter>? RangeFilters { get; set; }
    public List<DateRangeFilter>? DateRangeFilters { get; set; }
    public string? SortBy { get; set; }
    public string? SearchString { get; set; }

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
        stringBuilder.Append("],");

        stringBuilder.Append("SortBy: ");
        stringBuilder.Append(SortBy);
        stringBuilder.Append(", ");

        stringBuilder.Append("SearchString: ");
        stringBuilder.Append(SearchString);
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

    public EqualFilter()
    {
        PropertyName = string.Empty;
    }

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
    public double? MinValue { get; set; }
    public double? MaxValue { get; set; }

    public RangeFilter()
    {
        PropertyName = string.Empty;
    }

    public override string ToString()
    {
        return $"{{ PropertyName: {PropertyName}, MinValue: {MinValue}, MaxValue: {MaxValue} }}";
    }
}

public class DateRangeFilter
{
    public DateRangeFilter()
    {
        PropertyName = string.Empty;
    }

    public string PropertyName { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }

    public override string ToString()
    {
        return $"{{ PropertyName: {PropertyName}, FromDate: {FromDate}, ToDate: {ToDate} }}";
    }
}
