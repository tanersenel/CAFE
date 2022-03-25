using CAFE.DATA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CAFE.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(int id);
        public Task<List<User>> GetUsers();
        public Task<List<User>> GetUsersByName(string name);
        public Task<User> AddUser(User usr);
        public Task<User> UpdateUser(User usr);
        public Task<User> GetUser(User Usr);
        public Task<bool> Delete(int id);
    }
}
