using System.Linq.Dynamic.Core;

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
        List<EqualFilter> equalFilters
    )
    {
        if (equalFilters != null && equalFilters.Any())
        {
            foreach (var property in equalFilters)
            {
                string propertyName = property.PropertyName;
                string propertyValue = property.PropertyValue;
                if (!string.IsNullOrEmpty(propertyValue))
                    query = query.Where($"{propertyName} = @0", propertyValue);
            }
        }

        return query;
    }

    public static IQueryable<T> ApplyDateRangeFilter<T>(
        this IQueryable<T> query,
        List<DateRangeFilter> dateRangeFilters
    )
    {
        if (dateRangeFilters != null && dateRangeFilters.Any())
        {
            foreach (var filterOptions in dateRangeFilters)
            {
                DateTime fromDate;
                bool hasFromDate = DateTime.TryParse(filterOptions.FromDate, out fromDate);

                if (hasFromDate)
                {
                    query = query.Where($"{filterOptions.PropertyName} >= @0", fromDate);
                }

                DateTime toDate;
                bool hasToDate = DateTime.TryParse(filterOptions.ToDate, out toDate);

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
        List<RangeFilter> rangeFilters
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
                    int temp = minValue;
                    minValue = maxValue;
                    maxValue = temp;
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
        string sortBy,
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
