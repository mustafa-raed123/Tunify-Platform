using Tunify_Platform.Data.Models;

namespace Tunify_Platform.Reposiories.Interface
{
    public interface IUsers
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> UpdateUser(int Id  , User user);
        public Task<int> DeleteUser(int Id);
        public Task<User> GetUserById(Task<int> id);
        public Task<User> CreateUser(User user);
    }
}
