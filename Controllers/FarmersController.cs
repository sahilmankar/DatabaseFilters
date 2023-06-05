using FarmersAPI.Extensions;
using FarmersAPI.Models;
using FarmersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FarmersAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FarmersController : ControllerBase
    {
        private readonly IFarmerService _srv;

        public FarmersController(IFarmerService srv)
        {
            this._srv = srv;
        }

        [HttpGet]
        public async Task<List<Farmer>> GetFarmers()
        {
            return await _srv.GetFarmers();
        }

        [HttpGet("{id}")]
        public async Task<Farmer> GetFarmer(int id)
        {
            return await _srv.GetFarmer(id);
        }

        [HttpGet("collections/{id}")]
        public async Task<List<FarmerCollection>> GetFarmerCollections(int id)
        {
            return await _srv.GetFarmerCollections(id);
        }

        [HttpGet("collectionsamountpermonth/{id}")]
        public async Task<List<FarmerCollectionPerMonth>> GetFarmerCollectionAmountByMonth(int id)
        {
            return await _srv.GetFarmerCollectionAmountByMonth(id);
        }

        [HttpGet("collectionsamountbycrop/{id}")]
        public async Task<List<FarmerCollectionByCrop>> GetFarmerCollectionAmountByCrop(int id)
        {
            return await _srv.GetFarmerCollectionAmountByCrop(id);
        }

        [HttpPost("datefilter/{id}")]
        public async Task<List<FarmerCollection>> GetFarmerCollectionsBetweenDates(
            int id,
            DateFilter dateFilter
        )
        {
            return await _srv.GetFarmerCollectionsBetweenDates(id, dateFilter);
        }

        [HttpGet("{id}/crops/{id1}")]
        public async Task<List<FarmerCollection>> GetFarmerCollectionByCrop(int id, int id1)
        {
            return await _srv.GetFarmerCollectionByCrop(id, id1);
        }

        [HttpPost("filter/{id}")]
        public List<FarmerCollection> FilterRecords(
            int id,
            [FromBody] FilterRequest request,
            [FromQuery] int pageNumber,
            [FromQuery] string? lastItem
        )
        {
            var records = _srv.FilterRecords(id, request, pageNumber);

            var metadata = new
            {
                records.TotalCount,
                records.CurrentPage,
                records.TotalPages,
                records.HasNext,
                records.HasPrevious
            };
        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return records;
        }
    }
}
