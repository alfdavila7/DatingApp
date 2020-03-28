using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IDatingRepository
    {
         void Add<T> (T entity) where T: class; // Generic in order to be able to delete photos and users
         void Delete<T> (T entity) where T: class;
         Task<bool> SaveAll(); // Check if there is more than one change in the Db
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}