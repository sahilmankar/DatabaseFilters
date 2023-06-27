
using FarmersAPI.Models;
using FarmersAPI.Repositories.Interfaces;

namespace FarmersAPI.Repositories;

public class FilterHelperRepository:IFilterHelperRepository
{

   //this will give properties grouped by datatype string,(int or double),DateTime
    public PropertyCategorization  GetPropertyCategorization()
    {
        var categorizedProperties = new PropertyCategorization
        {
            EqualProperties = new List<string>(),
            RangeProperties = new List<string>(),
            DateProperties = new List<string>()
        };

        var farmerCollectionDtoType = typeof(FarmerCollectionDTO);
        var properties = farmerCollectionDtoType.GetProperties();

        foreach (var property in properties)
        {
            // Exclude read-only properties by checking if they have a setter
            if (property.GetSetMethod() != null)
            {
                if (property.PropertyType == typeof(string))
                {
                    categorizedProperties.EqualProperties.Add(property.Name);
                }
                else if (
                    property.PropertyType == typeof(int) || property.PropertyType == typeof(double)
                )
                {
                    categorizedProperties.RangeProperties.Add(property.Name);
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    categorizedProperties.DateProperties.Add(property.Name);
                }
            }
        }
        return  categorizedProperties;
    }

    // It will give all properties of a class -- for choosing sort by property
    public  List<string> GetPropertyNames()
    {
        var propertyNames = new List<string>();
        var properties = typeof(FarmerCollectionDTO).GetProperties();
        foreach (var property in properties)
        {
            if (property.CanRead && property.CanWrite)
            {
                propertyNames.Add(property.Name);
            }
        }
        return propertyNames;
    }
}