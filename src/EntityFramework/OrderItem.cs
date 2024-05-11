using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.EntityFramework
{
  [Table("OrderItem")]
  public class OrderItem
  {
    [Key]
    [Column("orderItem_id")]
    public Guid OrderItemId { get; set; }
    
    [Column("order_id")]
    public Guid OrderId { get; set; }//Foreign Key
    
    [Column("product_id")]
    public Guid ProductId { get; set; }//Foreign Key

    [Required(ErrorMessage = "Quantity is required.")]
    [MinLength(1, ErrorMessage = "Quantity must have at least 1 ")]
    [Column("quantity")]
    public int Quantity { get; set; }

    // Relationships
    
    public Order? Order { get; set; }

    public Product? Product { get; set; }
  }
}