using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.EntityFramework
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }

        public bool IsBanned { get; set; }

        public DateTime CreatedAt { get; set; }
        public List<Order>? Orders { get; set; } // By Atheer
    }
}