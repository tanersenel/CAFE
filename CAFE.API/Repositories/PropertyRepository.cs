using CAFE.API.Repositories.Interfaces;
using CAFE.DATA.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAFE.API.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        public async Task<List<Property>> GetProperties()
        {
            using (var db = new CAFEDBEntities())
            {
                var properties = await db.Properties.ToListAsync();
                return properties;  
            }
        }

        public async Task<Property> GetPropertyById(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var properties = await db.Properties.FirstOrDefaultAsync(x=>x.Propertyid==id);
                return properties;
            }
        }
        public async Task<List<Property>> GetPropertiesByKey(string key)
        {
            using (var db = new CAFEDBEntities())
            {
                var properties = await db.Properties.Where(x=>x.Key.Contains(key)).ToListAsync();
                return properties;
            }
        }

        public async Task<Property> AddProperty(Property property)
        {
            using (var db = new CAFEDBEntities())
            {
                db.Properties.Add(property);
                await db.SaveChangesAsync();

                return property;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var prop = db.Properties.FirstOrDefault(x => x.Propertyid == id);
                if (prop != null)
                {
                    db.Properties.Remove(prop);
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
