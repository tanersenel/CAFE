using CAFE.API.Repositories.Interfaces;
using CAFE.DATA.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CAFE.API.Extensions;

namespace CAFE.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> AddUser(User usr)
        {
            using (var db = new CAFEDBEntities())
            {
                usr.Hashpassword = usr.Saltpassword.Encrypt();
                db.Users.Add(usr);
                await db.SaveChangesAsync();
                return usr; 
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var usr = db.Users.FirstOrDefault(x=>x.Userid==id);    
                db.Users.Add(usr);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<User> GetUser(User Usr)
        {
            using (var db = new CAFEDBEntities())
            {
                var usr = await db.Users.FirstOrDefaultAsync(x => x.Username == Usr.Username && x.Hashpassword == Usr.Saltpassword.Encrypt());
               
                return usr;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (var db = new CAFEDBEntities())
            {
                var usr = await db.Users.FirstOrDefaultAsync(x => x.Userid == id);

                return usr;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            using (var db = new CAFEDBEntities())
            {
                var usr = await db.Users.ToListAsync();

                return usr;
            }
        }

        public async Task<List<User>> GetUsersByName(string name)
        {
            using (var db = new CAFEDBEntities())
            {
                var users = await db.Users.Where(x => x.Name.Contains(name)).ToListAsync();

                return users;
            }
        }

        public async Task<User> UpdateUser(User usr)
        {
            using (var db = new CAFEDBEntities())
            {
                usr.Hashpassword = usr.Saltpassword.Encrypt();
                db.Users.Update(usr);
                await db.SaveChangesAsync();
                return usr;
            }
        }
    }
}
