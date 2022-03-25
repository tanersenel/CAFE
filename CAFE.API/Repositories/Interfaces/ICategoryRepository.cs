using CAFE.DATA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAFE.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> GetCategoryById(int id);
        public Task<List<Category>> GetMainCategories();
        public Task<Category> AddCategory(Category category);
        public Task<Category> UpdateCategory(Category category);
        public Task<List<Category>> GetSubCategories(int id);
        public Task<bool> Delete(int id);
    }
}
