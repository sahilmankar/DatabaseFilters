using FarmersAPI.Models;
using FarmersAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FarmersAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FilterHelperController : ControllerBase
    {
        private readonly IFilterHelperService _srv;
        public FilterHelperController(IFilterHelperService srv)
        {
            _srv = srv;
        }

        [HttpGet("categorizedProperties")]
        public PropertyCategorization GetPropertyCategorization()
        {
            return _srv.GetPropertyCategorization();
        }

        [HttpGet("getpropertynames")]
        public List<string> GetPropertyNames()
        {
            return _srv.GetPropertyNames();
        }
        
    }
}