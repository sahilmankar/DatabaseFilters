using FarmersAPI.Models;
using FarmersAPI.Repositories.Interfaces;
using FarmersAPI.Services.Interfaces;

namespace FarmersAPI.Services;

public class FilterHelperService<T> : IFilterHelperService<T>
{
    private readonly IFilterHelperRepository<T> _repo;

    public FilterHelperService(IFilterHelperRepository<T> repo)
    {
        this._repo = repo;
    }

    public List<string> GetDateRangeProperties()
    {
        return _repo.GetDateRangeProperties();
    }

    public List<string> GetEqualProperties()
    {
        return _repo.GetEqualProperties();
    }

    public List<string> GetPropertyNames()
    {
        return _repo.GetPropertyNames();
    }

    public List<string> GetRangeProperties()
    {
        return _repo.GetRangeProperties();
    }
}
