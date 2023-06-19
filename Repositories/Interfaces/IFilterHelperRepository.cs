using FarmersAPI.Models;

namespace FarmersAPI.Repositories.Interfaces;

public interface IFilterHelperRepository
{
    PropertyCategorization GetPropertyCategorization();
    List<string> GetPropertyNames();
}