using FarmersAPI.Extensions;
using FarmersAPI.Models;

namespace FarmersAPI.Repositories.Interfaces;

public interface IFarmerRepository
{
    Task<List<Farmer>> GetFarmers();
    Task<Farmer> GetFarmer(int farmerId);
    Task<List<FarmerCollection>> GetFarmerCollections(int farmerId);
    PagedList<FarmerCollectionDTO>? FilterRecords(
        int farmerId,
        FilterRequest request,
        int pageNumber
    );

    Task<List<string>> GetCrops();
    Task<List<string?>> GetGrades();
    Task<List<string?>> GetContainerTypes();
    List<Farmer> GetFarmerByName(string name);
    PagedList<CollectionBillingDTO>? GetAllCollectionsWithBilling(
        FilterRequest request,
        int pageNumber
    );
}
