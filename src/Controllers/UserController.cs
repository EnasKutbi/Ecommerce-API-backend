using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Model;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersService();
                if (users.Count() < 1)
                {
                    return NotFound(new ErrorResponse { Success = false, Message = "There are no users to display" });
                }
                else
                {
                    return Ok(new SuccessResponse<IEnumerable<User>> { Success = true, Message = "All users are returned successfully", Data = users });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred when trying to get all users");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            try
            {
                if (!Guid.TryParse(userId, out Guid userIdGuid))
                {
                    return BadRequest("Invalid user ID format");
                }

                var user = await _userService.GetUserById(userIdGuid);
                if (user == null)
                {
                    return NotFound(new ErrorResponse { Success = false, Message = "No user found" });
                }
                else
                {
                    return Ok(new SuccessResponse<User> { Success = true, Message = "User is returned successfully", Data = user });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred when trying to get a user");
                return StatusCode(500, new ErrorResponse { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User newUser)
        {
            try
            {
                var createdUser = await _userService.CreateUserService(newUser);
                return CreatedAtAction(nameof(GetUser), new { userId = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine("User cannot be created");
                return StatusCode(500, new ErrorResponse { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, User updateUser)
        {
            try
            {
                if (!Guid.TryParse(userId, out Guid userIdGuid))
                {
                    return BadRequest("Invalid user ID format");
                }

                var user = await _userService.UpdateUserService(userIdGuid, updateUser);
                if (user == null)
                {
                    return NotFound(new ErrorResponse { Success = false, Message = "No user found" });
                }
                else
                {
                    return Ok(new SuccessResponse<User> { Success = true, Message = "User is updated successfully", Data = user });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("User cannot be updated");
                return StatusCode(500, new ErrorResponse { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                if (!Guid.TryParse(userId, out Guid userIdGuid))
                {
                    return BadRequest("Invalid user ID format");
                }

                var result = await _userService.DeleteUserService(userIdGuid);
                if (!result)
                {
                    return NotFound(new ErrorResponse { Success = false, Message = "No user found" });
                }
                else
                {
                    return Ok(new SuccessResponse<User> { Success = true, Message = "User is deleted successfully" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("User cannot be deleted");
                return StatusCode(500, new ErrorResponse { Success = false, Message = ex.Message });
            }
        }
    }
}