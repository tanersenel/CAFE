using CAFE.DATA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAFE.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> GetProductById(int id);
        public Task<List<Product>> GetAllProducts();
        public Task<Product> AddProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task<bool> Delete(int id);
        public Task<List<Product>> GetProductByCategoryId(int id);
        public Task<List<Product>> GetProductsByKey(string key);
    }
}
