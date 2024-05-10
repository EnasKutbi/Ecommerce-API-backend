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
            return await _appDbContext.Users.Include(user => user.Orders).ToListAsync();
        }

        public Task<User?> GetUserById(Guid userId)
        {
            return await _appDbContext.Users.Include(user => user.Orders).FirstOrDefaultAsync(user => user.UserId == userId);
        }

        public async Task<User> CreateUserService(User newUser)
        {
            await Task.CompletedTask; // Simulate an asynchronous operation without delay
            newUser.UserId = Guid.NewGuid();
            newUser.CreatedAt = DateTime.Now;
            _users.Add(newUser); // store this user in our database
            return newUser;
        }

        public async Task<User?> UpdateUserService(Guid userId, User updateUser)
        {
            await Task.CompletedTask; // Simulate an asynchronous operation without delay
            var existingUser = _users.FirstOrDefault(u => u.UserId == userId);
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
            return existingUser;
        }

        public async Task<bool> DeleteUserService(Guid userId)
        {
            await Task.CompletedTask; // Simulate an asynchronous operation without delay
            var userToRemove = _users.FirstOrDefault(u => u.UserId == userId);
            if (userToRemove != null)
            {
                _users.Remove(userToRemove);
                return true;
            }
            return false;
        }
    }
}