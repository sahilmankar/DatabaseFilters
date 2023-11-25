namespace EmployeeAPI.Extensions;

public class PropertyHelper
{
    public static FilterPropertiesList GetAllProperties<T>()
    {
        FilterPropertiesList properties = new FilterPropertiesList()
        {
            EqualProperties = GetEqualProperties<T>(),
            DateRangeProperties = GetDateRangeProperties<T>(),
            RangeProperties = GetRangeProperties<T>(),
            AllProperties = GetPropertyNames<T>()
        };
        return properties;
    }

    public static List<string> GetPropertyNames<T>()
    {
        var propertyNames = typeof(T)
            .GetProperties()
            .Where(
                property => !property.Name.Contains("Id") && property.CanRead && property.CanWrite
            )
            .Select(property => property.Name)
            .ToList();

        return propertyNames;
    }

    public static List<string> GetEqualProperties<T>()
    {
        var propertyNames = typeof(T)
            .GetProperties()
            .Where(
                property =>
                    property.GetSetMethod() != null && property.PropertyType == typeof(string)
            )
            .Select(property => property.Name)
            .ToList();

        return propertyNames;
    }

    public static List<string> GetRangeProperties<T>()
    {
        var propertyNames = typeof(T)
            .GetProperties()
            .Where(
                property =>
                    !property.Name.Contains("Id")
                    && property.GetSetMethod() != null
                    && (
                        property.PropertyType == typeof(int)
                        || property.PropertyType == typeof(double)
                    )
            )
            .Select(property => property.Name)
            .ToList();
        return propertyNames;
    }

    public static List<string> GetDateRangeProperties<T>()
    {
        var propertyNames = typeof(T)
            .GetProperties()
            .Where(
                property =>
                    property.GetSetMethod() != null && property.PropertyType == typeof(DateTime)
            )
            .Select(property => property.Name)
            .ToList();
        return propertyNames;
    }
}
