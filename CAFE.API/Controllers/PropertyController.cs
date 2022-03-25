using CAFE.API.Repositories.Interfaces;
using CAFE.DATA.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CAFE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
       
        [HttpGet("GetProperties")]
        public List<Property> GetProperties()
        {
            var property = _propertyRepository.GetProperties();
            return property.Result;
        }
        
        [HttpGet("GetPropertyById/{id}")]
        public Property GetPropertyById(int id)
        {
           var property =  _propertyRepository.GetPropertyById(id);
            return property.Result;
        }
        [HttpGet("GetPropertiesByKey/{key}")]
        public List<Property> GetPropertiesByKey(string key)
        {
            var property = _propertyRepository.GetPropertiesByKey(key);
            return property.Result;
        }

        // POST api/<ProductController>
        [HttpPost("AddProperty")]
        public Property AddProperty([FromBody] Property property)
        {
            var prop = _propertyRepository.AddProperty(property);
            return prop.Result;
        }
        [HttpDelete("DeleteProperty/{id}")]
        public bool DeleteProperty(int id)
        {
            var property = _propertyRepository.Delete(id);
            return property.Result;
        }


    }
}
