using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.EntityFramework
{
    public class ProductModule
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Product name is required!")]
        [MinLength(5, ErrorMessage = "product name must be at least 5 characters long.")]
        [MaxLength(50, ErrorMessage = "product name must be at  50 characters long.")]
        public string Name { get; set; }
        public required string Slug { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        [MaxLength(300, ErrorMessage = "Description can be at most 300 characters long.")]
        public string Description { get; set; } = string.Empty;
        public required double Price { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public double Shipping { get; set; }
        public Guid CategoryId { get; set; }
        public Category category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}



















