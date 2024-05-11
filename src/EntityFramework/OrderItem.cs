using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.EntityFramework
{
  [Table("OrderItem")]
  public class OrderItem
  {
    
    // [ForeignKey("OrderId")]
    [Key]
    public Guid OrderId { get; set; }

    // [ForeignKey("ProductId")]
     [Key]
    public Guid ProductId { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [MinLength(1)]
    public int Quantity { get; set; }

    // Relationships
  
    public Order Order { get; set; }

    public Product Product { get; set; }
  }
}