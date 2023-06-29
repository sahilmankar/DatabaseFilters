using FarmersAPI.Models;

namespace FarmersAPI.Repositories.Interfaces;

public interface IFilterHelperRepository<T>
{
    List<string> GetPropertyNames();
    List<string> GetEqualProperties();
    List<string> GetRangeProperties();
    List<string> GetDateRangeProperties();
}
