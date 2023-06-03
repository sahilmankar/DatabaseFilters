using System.Globalization;
using FarmersAPI.Contexts;
using FarmersAPI.Models;
using FarmersAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using FarmersAPI.Extensions;
using Microsoft.AspNetCore.Http.Extensions;

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
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                var farmers = await (
                    from farmer in context.Farmers
                    join userRole in context.UserRoles on farmer.Id equals userRole.UserId
                    join role in context.Roles on userRole.RoleId equals role.Id
                    where role.Name == "farmer"
                    select farmer
                ).ToListAsync();
                if (farmers == null)
                {
                    return null;
                }
                return farmers;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<Farmer> GetFarmer(int farmerId)
    {
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                Farmer? farmer = await (
                    from f in context.Farmers
                    join userRole in context.UserRoles on f.Id equals userRole.UserId
                    join role in context.Roles on userRole.RoleId equals role.Id
                    where role.Name == "farmer" && f.Id == farmerId
                    select f
                ).FirstOrDefaultAsync();
                if (farmer == null)
                {
                    return null;
                }
                return farmer;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<FarmerCollection>> GetFarmerCollections(int farmerId)
    {
        // int pagesize=10;
        // int page=1;
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
                // collections=collections.Skip((page-1)*pagesize).Take(pagesize).ToList();
                Console.WriteLine(collections.Count);
                return collections;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<FarmerCollection>> GetFarmerCollectionsBetweenDates(
        int farmerId,
        DateFilter dateFilter
    )
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
                    where
                        collection.FarmerId == farmerId
                        && (
                            dateFilter.StartDate == default
                            || collection.Date >= dateFilter.StartDate
                        )
                        && (dateFilter.EndDate == default || collection.Date <= dateFilter.EndDate)
                    orderby collection.Date ascending
                    select new FarmerCollection()
                    {
                        Collection = collection,
                        Billing = bill,
                        Crop = crop.Title
                    }
                ).ToListAsync();
                return collections;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<FarmerCollection>> GetFarmerCollectionByCrop(int farmerId, int cropId)
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
                    where collection.FarmerId == farmerId && crop.Id == cropId
                    orderby collection.Date ascending
                    select new FarmerCollection()
                    {
                        Collection = collection,
                        Billing = bill,
                        Crop = crop.Title
                    }
                ).ToListAsync();
                return collections;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<FarmerCollectionPerMonth>> GetFarmerCollectionAmountByMonth(int farmerId)
    {
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                var farmerCollectionPerMonths = await (
                    from billing in context.Billings
                    join collection in context.Collections
                        on billing.CollectionId equals collection.Id
                    where collection.FarmerId == farmerId
                    group billing by new { billing.Date.Year, billing.Date.Month } into billingGroup
                    select new FarmerCollectionPerMonth()
                    {
                        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(
                            billingGroup.Key.Month
                        ),
                        Year = billingGroup.Key.Year,
                        TotalAmount = billingGroup.Sum(billing => billing.TotalAmount),
                    }
                ).ToListAsync();
                return farmerCollectionPerMonths;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<FarmerCollectionByCrop>> GetFarmerCollectionAmountByCrop(int farmerId)
    {
        try
        {
            using (var context = new FarmersContext(_configuration))
            {
                var collectionByCrops = await (
                    from billing in context.Billings
                    join collection in context.Collections
                        on billing.CollectionId equals collection.Id
                    join crop in context.Crops on collection.CropId equals crop.Id
                    where collection.FarmerId == farmerId
                    group billing by new { billing.Date.Year, crop.Title } into billingGroup
                    select new FarmerCollectionByCrop()
                    {
                        Crop = billingGroup.Key.Title,
                        Year = billingGroup.Key.Year,
                        TotalAmount = billingGroup.Sum(billing => billing.TotalAmount),
                    }
                ).ToListAsync();
                return collectionByCrops;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public PagedList<FarmerCollection> FilterRecords(int farmerId, FilterRequest request,int pageNumber)
    {
        var context = new FarmersContext(_configuration);
        var query =
            from collection in context.Collections
            join bill in context.Billings on collection.Id equals bill.CollectionId
            join farmer in context.Farmers on collection.FarmerId equals farmer.Id
            join crop in context.Crops on collection.CropId equals crop.Id
            where collection.FarmerId == farmerId
            select new FarmerCollection()
            {
                Collection = collection,
                Billing = bill,
                Crop = crop.Title
            };
        query = query.ApplyFilters(request);
        return PagedList<FarmerCollection>.ToPagedList(query,pageNumber);
    }


// json format to send filter request
// {
//     "EqualFilters": [
//         {
//             "PropertyName": "Collection.Grade",
//             "PropertyValue": "A"
//         },
//         {
//             "PropertyName": "Crop",
//             "PropertyValue": "Potato"
//         }
//     ],
//     "RangeFilters": [
//         {
//             "PropertyName": "billing.totalAmount",
//             "MinValue": 20000,
//             "MaxValue": 5000
//         }
//     ],
//     "DateRangeFilters": [
//         {
//             "PropertyName": "collection.date",
//             "FromDate": "2022-01-01",
//             "ToDate": "2022-12-31"
//         }
//     ],
//     "SortBy": "collection.date",
//     "SortAscending": true
// }




    // private IQueryable<FarmerCollection> ApplyFilters(
    //     IQueryable<FarmerCollection> query,
    //     FilterRequest request
    // )
    // {
    //     query = ApplyEqualFilters(query, request.EqualFilters);
    //     query = ApplyDateRangeFilter(query, request.DateRangeFilters);
    //     query = ApplyPropertyRangesFilter(query, request.RangeFilters);
    //     query = ApplySorting(query, request.SortBy, request.SortAscending);
    //     return query;
    // }

    // private IQueryable<FarmerCollection> ApplyEqualFilters(
    //     IQueryable<FarmerCollection> query,
    //     List<EqualFilter>? equalFilters
    // )
    // {
    //     if (equalFilters != null && equalFilters.Any())
    //     {
    //         foreach (var property in equalFilters)
    //         {
    //             string propertyName = property.PropertyName;
    //             string propertyValue = property.PropertyValue;
    //             if (!string.IsNullOrEmpty(propertyValue))
    //                 query = query.Where($"{propertyName} = @0", propertyValue);
    //         }
    //     }

    //     return query;
    // }

    // private IQueryable<FarmerCollection> ApplyDateRangeFilter(
    //     IQueryable<FarmerCollection> query,
    //     List<DateRangeFilter> dateRangeFilters
    // )
    // {
    //     foreach (var filterOptions in dateRangeFilters)
    //     {
    //         DateTime fromDate;
    //         bool hasFromDate = DateTime.TryParse(filterOptions.FromDate, out fromDate);

    //         if (hasFromDate)
    //         {
    //             query = query.Where($"{filterOptions.PropertyName} >= @0", fromDate);
    //         }

    //         DateTime toDate;
    //         bool hasToDate = DateTime.TryParse(filterOptions.ToDate, out toDate);

    //         if (hasToDate)
    //         {
    //             query = query.Where($"{filterOptions.PropertyName} <= @0", toDate);
    //         }
    //     }

    //     return query;
    // }

    // private IQueryable<FarmerCollection> ApplyPropertyRangesFilter(
    //     IQueryable<FarmerCollection> query,
    //     List<RangeFilter>? rangeFilters
    // )
    // {
    //     if (rangeFilters != null && rangeFilters.Any())
    //     {
    //         foreach (var property in rangeFilters)
    //         {
    //             string propertyName = property.PropertyName;
    //             int minValue = property.MinValue;
    //             int maxValue = property.MaxValue;

    //             if(minValue > maxValue && maxValue!=default){
    //                 int temp=minValue;
    //                 minValue=maxValue;
    //                 maxValue=temp;
    //             }

    //             if (minValue != default )
    //             {
    //                 query = query.Where($"{propertyName} >= @0", minValue);
    //             }
    //             if (maxValue != default )
    //             {
    //                 query = query.Where($"{propertyName} <= @0", maxValue);
    //             }
    //         }
    //     }

    //     return query;
    // }

    // private IQueryable<FarmerCollection> ApplySorting(
    //     IQueryable<FarmerCollection> query,
    //     string sortBy,
    //     bool sortAscending
    // )
    // {
    //     if (!string.IsNullOrEmpty(sortBy))
    //     {
    //         query = query.OrderBy($"{sortBy} {(sortAscending ? "ascending" : "descending")}");
    //     }

    //     return query;
    // }
}
