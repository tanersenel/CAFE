using CAFE.API.Repositories.Interfaces;
using CAFE.DATA.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CAFE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("GetMainCategories")]
        public List<Category> GetMainCategories()
        {
            return  _categoryRepository.GetMainCategories().Result; 
        }

        [HttpGet("GetSubCategories/{id}")]
        public List<Category> GetSubCategories(int id)
        {
            return _categoryRepository.GetSubCategories(id).Result;
        }
        [HttpGet("GetCategoryById/{id}")]
        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id).Result;
        }
        // POST api/<CategoryController>
        [HttpPost("Add")]
        public Category Add([FromBody] Category category)
        {
            return _categoryRepository.AddCategory(category).Result;
        }
        [HttpPost("Update")]
        public Category Update([FromBody] Category category)
        {
            return _categoryRepository.UpdateCategory(category).Result;
        }


        // DELETE api/<CategoryController>/5
        [HttpDelete("Delete/{id}")]
        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id).Result;
        }
    }
}
