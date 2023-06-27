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

        [HttpPost("filter/{id}")]
        public List<FarmerCollectionDTO>? FilterRecords(
            int id,
            [FromBody] FilterRequest request,
            [FromQuery] int pageNumber
        )
        {
            var records = _srv.FilterRecords(id, request, pageNumber);
            if (records != null)
            {
                var metadata = new
                {
                    records.TotalCount,
                    records.CurrentPage,
                    records.TotalPages,
                    records.HasNext,
                    records.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            }

            return records;
        }

        /*
        filterrequest object format
        {
    "equalFilters": [
        {
            "propertyName": "Crop",
            "propertyValues": [
                "Bitroot",
                "Brinjal",
                "Cabbage"
            ]
        },
        {
            "propertyName": "ContainerType",
            "propertyValues": [
                "crates"
            ]
        },
        {
            "propertyName": "Grade",
            "propertyValues": [
                "A"
            ]
        }
    ],
    "rangeFilters": [
        {
            "propertyName": "CollectionId",
            "minValue": 1,
            "maxValue": 12
        }
    ],
    "dateRangeFilters": [
        {
            "propertyName": "CollectionDate",
            "fromDate": "2023-06-05",
            "toDate": "2023-06-06"
        }
    ],
    "sortAscending": false
    }
     
    */

        [HttpGet("getcrops")]
        public async Task<List<string>> GetCrops()
        {
            return await _srv.GetCrops();
        }

        [HttpGet("getgrades")]
        public async Task<List<string?>> GetGrades()
        {
            return await _srv.GetGrades();
        }

        [HttpGet("getcontainertypes")]
        public async Task<List<string?>> GetContainerTypes()
        {
            return await _srv.GetContainerTypes();
        }
    }
}
