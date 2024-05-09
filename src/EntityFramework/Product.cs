using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.EntityFramework
{
     [Table("Products")]
     public class Product
     {
          public Guid Id { get; set; }
          public string Name { get; set; }
          public required string Slug { get; set; }
          public string ImageUrl { get; set; } = string.Empty;
          public string Description { get; set; } = string.Empty;
          public required double Price { get; set; }
          public int Quantity { get; set; }
          public int Sold { get; set; }
          public double Shipping { get; set; }
          public Guid CategoryId { get; set; }//forien  key
          public Category Category { get; set; }
          public DateTime CreatedAt { get; set; }
     }
}

