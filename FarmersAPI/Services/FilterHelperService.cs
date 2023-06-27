using FarmersAPI.Models;
using FarmersAPI.Repositories.Interfaces;
using FarmersAPI.Services.Interfaces;

namespace FarmersAPI.Services;

public class FilterHelperService : IFilterHelperService
{
    private readonly IFilterHelperRepository _repo;

    public FilterHelperService( IFilterHelperRepository repo)
    {
        this._repo = repo;
    }
     public PropertyCategorization GetPropertyCategorization()
    {
       return _repo.GetPropertyCategorization();
    }

    public List<string> GetPropertyNames()
    {
        return _repo.GetPropertyNames();
    }
}