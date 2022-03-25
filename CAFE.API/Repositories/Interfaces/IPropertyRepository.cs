using CAFE.DATA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAFE.API.Repositories.Interfaces
{
    public interface IPropertyRepository
    {
        public Task<Property> GetPropertyById(int id);
        public Task<List<Property>> GetProperties();
        public Task<List<Property>> GetPropertiesByKey(string key);
        public Task<Property> AddProperty(Property property);
        public Task<bool> Delete(int id);
    }
}
