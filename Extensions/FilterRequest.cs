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
}

public class EqualFilter
{
    public string PropertyName { get; set; }
    public string? PropertyValue { get; set; }
}

public class RangeFilter
{
    public string PropertyName { get; set; }
    public int MinValue { get; set; }
    public int MaxValue { get; set; }
}

public class DateRangeFilter
{
    public string PropertyName { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
}
