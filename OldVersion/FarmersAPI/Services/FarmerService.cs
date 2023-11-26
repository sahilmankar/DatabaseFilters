using FarmersAPI.Extensions;
using FarmersAPI.Models;
using FarmersAPI.Repositories.Interfaces;
using FarmersAPI.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FarmersAPI.Services;

public class FarmerService : IFarmerService
{
    private readonly IFarmerRepository _repo;
    private readonly IMemoryCache _cache;

    public FarmerService(IFarmerRepository repo, IMemoryCache cache)
    {
        this._repo = repo;
        this._cache = cache;
    }

    public async Task<List<Farmer>> GetFarmers()
    {
        return await _repo.GetFarmers();
    }

    public async Task<Farmer> GetFarmer(int farmerId)
    {
        return await _repo.GetFarmer(farmerId);
    }

    public async Task<List<FarmerCollection>> GetFarmerCollections(int farmerId)
    {
        return await _repo.GetFarmerCollections(farmerId);
    }

    public PagedList<FarmerCollectionDTO>? FilterRecords(
        int farmerId,
        FilterRequest request,
        int pageNumber
    )
    {
        string cacheKey = farmerId + "_" + request.ToString() + "_" + pageNumber;
        Console.WriteLine(cacheKey);
        return _cache.GetOrCreate(
            cacheKey,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                Console.WriteLine("--> repo hit");
                var collecrions = _repo.FilterRecords(farmerId, request, pageNumber);
                return collecrions;
            }
        );
    }

    public async Task<List<string>> GetCrops()
    {
        return await _repo.GetCrops();
    }

    public async Task<List<string?>> GetGrades()
    {
        return await _repo.GetGrades();
    }

    public async Task<List<string?>> GetContainerTypes()
    {
        return await _repo.GetContainerTypes();
    }

    public List<Farmer> GetFarmerByName(string name)
    {
       return _repo.GetFarmerByName(name);
    }

    public PagedList<CollectionBillingDTO>? GetAllCollectionsWithBilling(FilterRequest request, int pageNumber)
    {
         string cacheKey =  request.ToString() + "_" + pageNumber;
        Console.WriteLine(cacheKey);
        return _cache.GetOrCreate(
            cacheKey,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                Console.WriteLine("--> repo hit");
                var collecrions = _repo.GetAllCollectionsWithBilling(request, pageNumber);
                return collecrions;
            }
        );
    }
}
