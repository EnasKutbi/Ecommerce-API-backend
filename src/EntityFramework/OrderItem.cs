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
<<<<<<< HEAD
    public Guid OrderId { get; set; }

    // [ForeignKey("ProductId")]
     [Key]
    public Guid ProductId { get; set; }
=======
    [Column("orderItem_id")]
    public Guid OrderItemId { get; set; }
    
    [Column("order_id")]
    public Guid OrderId { get; set; }//Foreign Key
    
    [Column("product_id")]
    public Guid ProductId { get; set; }//Foreign Key
>>>>>>> 7636f781c269c3b30565bcfe0a24518d7a6931e8

    [Required(ErrorMessage = "Quantity is required.")]
    [MinLength(1, ErrorMessage = "Quantity must have at least 1 ")]
    [Column("quantity")]
    public int Quantity { get; set; }

    // Relationships
<<<<<<< HEAD
  
    public Order Order { get; set; }

    public Product Product { get; set; }
=======
    
    public Order? Order { get; set; }

    public Product? Product { get; set; }
>>>>>>> 7636f781c269c3b30565bcfe0a24518d7a6931e8
  }
}