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
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [MinLength(1)]
    public int Quantity { get; set; }

    // Relationships
    [ForeignKey("OrderId")]
    public Order Order { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
  }
}