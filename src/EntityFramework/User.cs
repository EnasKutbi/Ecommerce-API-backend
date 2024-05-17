using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.EntityFramework
{
    [Table("Users")]
    public class User
    {
        public Guid UserId { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public bool IsAdmin { get; set; } = false;

        public bool IsBanned { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}