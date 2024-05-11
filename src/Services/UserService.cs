using System;
using System.Collections.Generic;
using System.Linq;
using api.EntityFramework;
using api.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api.Services
{
    public class UserService
    {
        private AppDbContext _appDbContext;
        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersService()
        {
            return await _appDbContext.Users.Include(o => o.Orders).ToListAsync();
        }

        public async Task<User?> GetUserById(Guid userId)
        {
            return await _appDbContext.Users.Include(o => o.Orders).FirstOrDefaultAsync(user => user.UserId == userId);
        }

        public async Task<User> CreateUserService(User newUser)
        {
            newUser.UserId = Guid.NewGuid();
            newUser.CreatedAt = DateTime.UtcNow;
            _appDbContext.Users.Add(newUser);
            await _appDbContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<User?> UpdateUserService(Guid userId, User updateUser)
        {
            var existingUser = _appDbContext.Users.FirstOrDefault(u => u.UserId == userId);
            if (existingUser != null)
            {
                existingUser.Name = updateUser.Name;
                existingUser.Email = updateUser.Email;
                existingUser.Password = updateUser.Password;
                existingUser.Address = updateUser.Address;
                existingUser.Image = updateUser.Image;
                existingUser.IsAdmin = updateUser.IsAdmin;
                existingUser.IsBanned = updateUser.IsBanned;
            }
            await _appDbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUserService(Guid userId)
        {
            var userToRemove = _appDbContext.Users.FirstOrDefault(u => u.UserId == userId);
            if (userToRemove != null)
            {
                _appDbContext.Users.Remove(userToRemove);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}