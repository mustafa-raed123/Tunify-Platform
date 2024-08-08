using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Data.Models;
using Tunify_Platform.Reposiories.Interface;

namespace Tunify_Platform.Reposiories.Services
{
    public class UserService : IUsers
    {
        private readonly TunifyDbContext _tunifyDbContext;
        public UserService(TunifyDbContext tunifyDbContext)
        {
            _tunifyDbContext = tunifyDbContext;
        }


        public async Task<User> CreateUser(User user)
        {

            _tunifyDbContext.users.Add(user);
            await _tunifyDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int Id)
        {
            if (_tunifyDbContext.users == null)
            {
                return null;
            }
            User user = await _tunifyDbContext.users.FirstAsync(u => u.UserId == Id);
            if (user == null)
            {
                return null;
            }
            _tunifyDbContext.Entry(user).State = EntityState.Deleted;
            await _tunifyDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            if (_tunifyDbContext.users == null)
            {
                return null;

            }
            var users = await _tunifyDbContext.users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(int id)
        {

            var user = await _tunifyDbContext.users.FindAsync(id);
            if (user == null)
            {

                return null;
            }
            return user;

        }

        public async Task<User> UpdateUser(int Id, User user)
        {

            _tunifyDbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _tunifyDbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(Id))
                {
                    return null;
                }
            }

            return user;

        }
        private bool UserExists(int id)
        {
            return (_tunifyDbContext.users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
