using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class UpdateUserDto
    {
        [MinLength(2, ErrorMessage = "User name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "User name must be at most 50 characters long.")]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsBanned { get; set; }
    }
}