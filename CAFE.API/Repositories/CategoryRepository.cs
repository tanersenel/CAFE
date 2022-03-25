using CAFE.API.Repositories.Interfaces;
using CAFE.DATA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CAFE.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<Category> AddCategory(Category category)
        {
            using (var db = new CAFEDBEntities())
            {
                db.Categories.Add(category);    
                await db.SaveChangesAsync();
                return category;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var cat = db.Categories.FirstOrDefault(x => x.Categoryid == id);
                cat.Isdeleted= true; 
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Category>> GetMainCategories()
        {
            using (var db = new CAFEDBEntities())
            {
               var categories = await db.Categories.Where(x=>x.Isdeleted==false && x.Parentcategoryid==0).ToListAsync();
                
               return categories;
            }
        }

        public async Task<Category> GetCategoryById(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var categories = await db.Categories.FirstOrDefaultAsync(x => x.Isdeleted == false);

                return categories;
            }
        }

        public async Task<List<Category>> GetSubCategories(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var categories = await db.Categories.Where(x => x.Isdeleted == false && x.Parentcategoryid==id).ToListAsync();
                return categories;
            }
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            using (var db = new CAFEDBEntities())
            {
                db.Categories.Update(category);
                await db.SaveChangesAsync();
                return category;
            }
        }
    }
}
