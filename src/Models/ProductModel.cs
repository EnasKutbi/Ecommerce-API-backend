using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Models
{
    public class ProductModel
    {

        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required!")]
        [MinLength(5, ErrorMessage = "product name must be at least 5 characters long.")]
        [MaxLength(50, ErrorMessage = "product name must be at  50 characters long.")]
        public string Name { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public required double Price { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public double Shipping { get; set; }

        //Relation 1-M between category and Products
        public Guid CategoryId { get; set; }//Foreign Key
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //Relation M-M between Orders and Products
        public CategoryModel? Category { get; set; }
        List<OrderItemModel> OrderItems { get; set; }
    }
}



















