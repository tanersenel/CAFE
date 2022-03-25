using CAFE.API.Repositories.Interfaces;
using CAFE.DATA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CAFE.API.Extensions;

namespace CAFE.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product> AddProduct(Product product)
        {
            using (var db = new CAFEDBEntities())
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return product; 
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var product = db.Products.Include(x => x.Productproperties).FirstOrDefault(x => x.Productid == id && x.Isdeleted == false);
                if(product !=null)
                {
                    db.Products.Remove(product);
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
                
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            using (var db = new CAFEDBEntities())
            {
                var products = await db.Products.Where(x=> x.Isdeleted == false).Include(x=>x.Productproperties).ToListAsync();
               
                return products;

            }
        }

        public async Task<List<Product>> GetProductByCategoryId(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var categoryIds = db.Categories.Where(x => x.Parentcategoryid == id && x.Isdeleted == false).Select(x => x.Categoryid).ToList();
                categoryIds.Add(id);

                var products = await db.Products.Where(x=>categoryIds.Contains(x.Categoryid.Value)).Include(x => x.Productproperties).ToListAsync();

                return products;

            }
        }

        public async Task<Product> GetProductById(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var product = await db.Products.Include(x => x.Productproperties).FirstOrDefaultAsync(x => x.Productid == id && x.Isdeleted == false);
                
                return product;

            }
        }

        public async Task<List<Product>> GetProductsByKey(string key)
        {
            using (var db = new CAFEDBEntities())
            {
                var product = await db.Products.Where(x => x.Productname.Contains(key) && x.Isdeleted == false).Include(x => x.Productproperties).ToListAsync();

                return product;

            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            using (var db = new CAFEDBEntities())
            {
                db.Products.Update(product);
                await db.SaveChangesAsync();
                return product;
            }
        }
    }
}
