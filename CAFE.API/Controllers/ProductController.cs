using CAFE.API.Repositories.Interfaces;
using CAFE.DATA.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CAFE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        // GET: api/<ProductController>
        [HttpGet("GetProductById/{id}")]
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id).Result;
        }
        [HttpGet("GetProductByCategoryId/{id}")]
        public List<Product> GetProductByCategoryId(int id)
        {
            return _productRepository.GetProductByCategoryId(id).Result;
        }
        [HttpGet("GetProductsByKey/{key}")]
        public List<Product> GetProductsByKey(string key)
        {
            return _productRepository.GetProductsByKey(key).Result;
        }
        // GET api/<ProductController>/5
        [HttpGet("GetAllProducts")]
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts().Result;
        }

        // POST api/<ProductController>
        [HttpPost("Add")]
        public Product Add([FromBody] Product product)
        {
            return _productRepository.AddProduct(product).Result;
        }

        // PUT api/<ProductController>/5
        [HttpPut("Update")]
        public Product Put([FromBody] Product product)
        {
            return _productRepository.UpdateProduct(product).Result;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _productRepository.Delete(id).Result;
        }
    }
}
