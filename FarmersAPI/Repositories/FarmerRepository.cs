using FarmersAPI.Contexts;
using FarmersAPI.Models;
using FarmersAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using FarmersAPI.Extensions;

namespace FarmersAPI.Repositories;

public class FarmerRepository : IFarmerRepository
{
    private readonly IConfiguration _configuration;

    public FarmerRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<Farmer>> GetFarmers()
    {
        var farmers = new List<Farmer>();
        try
        {
            using var context = new FarmersContext(_configuration);
            farmers = await (
                from farmer in context.Farmers
                join userRole in context.UserRoles on farmer.Id equals userRole.UserId
                join role in context.Roles on userRole.RoleId equals role.Id
                where role.Name == "farmer"
                select farmer
            ).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        return farmers;
    }

    public async Task<Farmer> GetFarmer(int farmerId)
    {
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                var farmer = await (
                    from f in context.Farmers
                    join userRole in context.UserRoles on f.Id equals userRole.UserId
                    join role in context.Roles on userRole.RoleId equals role.Id
                    where role.Name == "farmer" && f.Id == farmerId
                    select f
                ).FirstOrDefaultAsync();

                return farmer ?? throw new Exception("Farmer not found"); // null-coalescing operator
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<string>> GetCrops()
    {
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                var crops = await (from crop in context.Crops select crop.Title).ToListAsync();
                return crops;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<string?>> GetGrades()
    {
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                var grades = await context.Collections
                    .Where(x => x.Grade != null)
                    .Select(x => x.Grade)
                    .Distinct()
                    .ToListAsync();
                grades.Sort();
                return grades;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<string?>> GetContainerTypes()
    {
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                var containerTypes = await context.Collections
                    .Where(x => x.ContainerType != null)
                    .Select(x => x.ContainerType)
                    .Distinct()
                    .ToListAsync();
                containerTypes.Sort();
                return containerTypes;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<FarmerCollection>> GetFarmerCollections(int farmerId)
    {
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                List<FarmerCollection>? collections = await (
                    from collection in context.Collections
                    join bill in context.Billings on collection.Id equals bill.CollectionId
                    join farmer in context.Farmers on collection.FarmerId equals farmer.Id
                    join crop in context.Crops on collection.CropId equals crop.Id
                    where collection.FarmerId == farmerId
                    orderby collection.Date descending
                    select new FarmerCollection()
                    {
                        Collection = collection,
                        Billing = bill,
                        Crop = crop.Title
                    }
                ).ToListAsync();
                Console.WriteLine(collections.Count);
                return collections;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public PagedList<FarmerCollectionDTO>? FilterRecords(
        int farmerId,
        FilterRequest request,
        int pageNumber
    )
    {
        using (var context = new FarmersContext(_configuration))
        {
            var query =
                from collection in context.Collections
                join bill in context.Billings on collection.Id equals bill.CollectionId
                join farmer in context.Farmers on collection.FarmerId equals farmer.Id
                join crop in context.Crops on collection.CropId equals crop.Id
                where collection.FarmerId == farmerId
                orderby collection.Date descending
                select new FarmerCollectionDTO()
                {
                    CollectionId = collection.Id,
                    Crop = crop.Title,
                    ContainerType = collection.ContainerType,
                    Quantity = collection.Quantity,
                    Grade = collection.Grade,
                    TotalWeight = collection.TotalWeight,
                    TareWeight = collection.TareWeight,
                    NetWeight = collection.NetWeight,
                    RatePerKg = collection.RatePerKg,
                    CollectionDate = collection.Date,
                    BillId = bill.Id,
                    LabourCharges = bill.LabourCharges,
                    TotalAmount = bill.TotalAmount,
                    BillingDate = bill.Date,
                };
            query = query.ApplyFilters(request);
            return PagedList<FarmerCollectionDTO>.ToPagedList(query, pageNumber);
        }
    }



     public  List<Farmer> GetFarmerByName(string name)
    {
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                var farmers = 
                    from f in context.Farmers
                    join userRole in context.UserRoles on f.Id equals userRole.UserId
                    join role in context.Roles on userRole.RoleId equals role.Id
                    where role.Name == "farmer" 
                    select f;
                    farmers=farmers.ApplySearching(name,"firstName");

                return farmers.ToList() ?? throw new Exception("Farmer not found"); // null-coalescing operator
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

     public PagedList<CollectionBillingDTO>? GetAllCollectionsWithBilling(
        FilterRequest request,
        int pageNumber
    )
    {
        using (var context = new FarmersContext(_configuration))
        {
            var query =
                from collection in context.Collections
                join bill in context.Billings on collection.Id equals bill.CollectionId
                join farmer in context.Farmers on collection.FarmerId equals farmer.Id
                join crop in context.Crops on collection.CropId equals crop.Id
                orderby collection.Date descending
                select new CollectionBillingDTO()
                {
                    CollectionId = collection.Id,
                    Crop = crop.Title,
                    ContainerType = collection.ContainerType,
                    FarmerName=farmer.FirstName+" "+farmer.LastName,
                    Quantity = collection.Quantity,
                    Grade = collection.Grade,
                    TotalWeight = collection.TotalWeight,
                    TareWeight = collection.TareWeight,
                    NetWeight = collection.NetWeight,
                    RatePerKg = collection.RatePerKg,
                    CollectionDate = collection.Date,
                    BillId = bill.Id,
                    LabourCharges = bill.LabourCharges,
                    TotalAmount = bill.TotalAmount,
                    BillingDate = bill.Date,
                };
            query = query.ApplyFilters(request);
            query=query.ApplySearching(request.SearchString,"FarmerName");
            return PagedList<CollectionBillingDTO>.ToPagedList(query, pageNumber);
        }
    }
}
