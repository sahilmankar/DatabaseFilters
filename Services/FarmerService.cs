using System.Text;
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

    public async Task<List<FarmerCollectionPerMonth>> GetFarmerCollectionAmountByMonth(int farmerId)
    {
        return await _repo.GetFarmerCollectionAmountByMonth(farmerId);
    }

    public async Task<List<FarmerCollectionByCrop>> GetFarmerCollectionAmountByCrop(int farmerId)
    {
        return await _repo.GetFarmerCollectionAmountByCrop(farmerId);
    }

    public async Task<List<FarmerCollection>> GetFarmerCollectionsBetweenDates(
        int farmerId,
        DateFilter dateFilter
    )
    {
        return await _repo.GetFarmerCollectionsBetweenDates(farmerId, dateFilter);
    }

    public async Task<List<FarmerCollection>> GetFarmerCollectionByCrop(int farmerId, int cropId)
    {
        return await _repo.GetFarmerCollectionByCrop(farmerId, cropId);
    }

    public PagedList<FarmerCollection> FilterRecords(
        int farmerId,
        FilterRequest request,
        int pageNumber
    )
    {
        PagedList<FarmerCollection> collections = null;
        String cacheKey = farmerId + "_" + request.ToString() + "_" + pageNumber;
         
        // bool isExist = _cache.TryGetValue(cacheKey, out collections);
        // if (!isExist)
        {
            collections = _repo.FilterRecords(farmerId, request, pageNumber);
            // var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(
            //     TimeSpan.FromSeconds(30)
            // );

            // _cache.Set(cacheKey, collections, cacheEntryOptions);
        }

        System.Console.WriteLine(cacheKey);
        return collections;
    }
}
