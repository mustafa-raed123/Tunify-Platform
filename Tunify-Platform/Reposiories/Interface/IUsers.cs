using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Reposiories.Interface
{
    public interface IUsers 
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> UpdateUser(int Id, User user);
        public Task<User> DeleteUser(int Id);
        public Task<User> GetUserById(int id);
        public Task<User> CreateUser(User user);
    }
}
