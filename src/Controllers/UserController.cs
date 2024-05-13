using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using api.Services;
using api.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;
        public UserController(UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersService();
                if (users.ToList().Count < 1)
                {
                    return NotFound(new ErrorResponse { Success = false, Message = "There is no users to display" });
                }
                else
                {
                    return Ok(new SuccessResponse<IEnumerable<UserDto>> { Success = true, Message = "all users are returned successfully", Data = users });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred here when tried get all users");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpGet("{userId}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            try
            {
                var user = await _userService.GetUserById(userId);
                if (user == null)
                {
                    return NotFound(new ErrorResponse { Success = false, Message = $"There is no user found with ID : {userId}" });
                }
                else
                {
                    return Ok(new SuccessResponse<User> { Success = true, Message = "user is returned successfully", Data = user });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred here when tried get user");
                return StatusCode(500, new ErrorResponse { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User newUser)
        {
            try
            {
                var createdUser = await _userService.CreateUserService(newUser);
                if (createdUser != null)
                {
                    return CreatedAtAction(nameof(GetUser), new { userId = createdUser.UserId }, createdUser);
                }
                else
                {
                    return Ok(new SuccessResponse<User>
                    {
                        Message = "User is created successfully",
                        Data = createdUser
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"user can not be created");
                return StatusCode(500, new ErrorResponse { Success = false, Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
                if (!ModelState.IsValid)
                {
                    return ApiResponse.BadRequest("Invalid User Data");
                }
                var loggedInUser = await _userService.LoginUserAsync(loginDto);

                var token = _authService.GenerateJwt(loggedInUser);


                return ApiResponse.Success(new { token, loggedInUser }, "User Logged In successfully");
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, User updateUser)
        {
            try
            {
                var user = await _userService.UpdateUserService(userId, updateUser);
                if (user == null)
                {
                    return NotFound(new ErrorResponse { Success = false, Message = "No user found" });
                }
                else
                {
                    return Ok(new SuccessResponse<User> { Success = true, Message = "user is updated successfully", Data = user });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"user can not be updated");
                return StatusCode(500, new ErrorResponse { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                var result = await _userService.DeleteUserService(userId);
                if (!result)
                {
                    return NotFound(new ErrorResponse { Success = false, Message = "No user found" });
                }
                else
                {
                    return Ok(new SuccessResponse<User> { Success = true, Message = "user is deleted successfully" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"user can not be deleted");
                return StatusCode(500, new ErrorResponse { Success = false, Message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile(Guid userId)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine($"{userIdString}");
            if (string.IsNullOrEmpty(userIdString))
            {
                return ApiResponse.Unauthorized("User Id is missing from token");
            }

            if (!Guid.TryParse(userIdString, out userId))
            {
                return ApiResponse.BadRequest("Invalid User Id");
            }
            var user = await _userService.GetUserById(userId);

            return ApiResponse.Success(user, "User profile is returned successfully");

        }

    }
}