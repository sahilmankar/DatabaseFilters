using System.Linq;
using FarmersAPI.Models;
using FarmersAPI.Repositories.Interfaces;

namespace FarmersAPI.Repositories
{
    public class FilterHelperRepository<T> : IFilterHelperRepository<T>
    {
        public List<string> GetPropertyNames()
        {
            var propertyNames = typeof(T)
                .GetProperties()
                .Where(property => property.CanRead && property.CanWrite)
                .Select(property => property.Name)
                .ToList();

            return propertyNames;
        }

        public List<string> GetEqualProperties()
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

        public List<string> GetRangeProperties()
        {
            var propertyNames = typeof(T)
                .GetProperties()
                .Where(
                    property =>
                        property.GetSetMethod() != null && property.PropertyType == typeof(int)
                        || property.PropertyType == typeof(double)
                )
                .Select(property => property.Name)
                .ToList();
            return propertyNames;
        }

        public List<string> GetDateRangeProperties()
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
}
