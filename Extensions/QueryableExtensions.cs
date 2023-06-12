using System.Linq.Dynamic.Core;
using System.Text;

namespace FarmersAPI.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, FilterRequest request)
    {
        query = query.ApplyEqualFilters(request.EqualFilters);
        query = query.ApplyDateRangeFilter(request.DateRangeFilters);
        query = query.ApplyPropertyRangesFilter(request.RangeFilters);
        query = query.ApplySorting(request.SortBy, request.SortAscending);
        return query;
    }

    public static IQueryable<T> ApplyEqualFilters<T>(
        this IQueryable<T> query,
        List<EqualFilter>? equalFilters
    )
    {
        if (equalFilters != null && equalFilters.Any())
        {
            foreach (var property in equalFilters)
            {
                var stringBuilder = new StringBuilder();
                string propertyName = property.PropertyName;
                var propertyValues = property.PropertyValues;
                if (propertyValues != null)
                {
                    foreach (string pvalue in propertyValues)
                    {
                        if (!string.IsNullOrEmpty(pvalue))
                        {
                            stringBuilder.Append($"{propertyName} = \"{pvalue}\" ");
                            stringBuilder.Append(" OR ");
                        }
                    }

                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Length -= 4; // Remove the trailing " OR "
                        string filterString = stringBuilder.ToString();
                        query = query.Where(filterString);
                    }
                }
            }
        }

        return query;
    }

    public static IQueryable<T> ApplyDateRangeFilter<T>(
        this IQueryable<T> query,
        List<DateRangeFilter>? dateRangeFilters
    )
    {
        if (dateRangeFilters != null && dateRangeFilters.Any())
        {
            foreach (var filterOptions in dateRangeFilters)
            {
                bool hasFromDate = DateTime.TryParse(filterOptions.FromDate, out DateTime fromDate);

                if (hasFromDate)
                {
                    query = query.Where($"{filterOptions.PropertyName} >= @0", fromDate);
                }

                bool hasToDate = DateTime.TryParse(filterOptions.ToDate, out DateTime toDate);

                if (hasToDate)
                {
                    query = query.Where($"{filterOptions.PropertyName} <= @0", toDate);
                }
            }
        }

        return query;
    }

    public static IQueryable<T> ApplyPropertyRangesFilter<T>(
        this IQueryable<T> query,
        List<RangeFilter>? rangeFilters
    )
    {
        if (rangeFilters != null && rangeFilters.Any())
        {
            foreach (var property in rangeFilters)
            {
                string propertyName = property.PropertyName;
                int minValue = property.MinValue;
                int maxValue = property.MaxValue;

                if (minValue > maxValue && maxValue != default)
                {
                    (maxValue, minValue) = (minValue, maxValue);   // int temp = minValue;
                                                                    // minValue = maxValue;
                                                                    // maxValue = temp;
                }

                if (minValue != default)
                {
                    query = query.Where($"{propertyName} >= @0", minValue);
                }
                if (maxValue != default)
                {
                    query = query.Where($"{propertyName} <= @0", maxValue);
                }
            }
        }

        return query;
    }

    public static IQueryable<T> ApplySorting<T>(
        this IQueryable<T> query,
        string? sortBy,
        bool sortAscending
    )
    {
        if (!string.IsNullOrEmpty(sortBy))
        {
            query = query.OrderBy($"{sortBy} {(sortAscending ? "ascending" : "descending")}");
        }
        return query;
    }
}
