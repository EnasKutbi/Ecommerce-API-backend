using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.EntityFramework;
using api.Model;

namespace api.Models
{
  public class OrderItemModel
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

    //Relations M-M between Orders and Products
    public OrderModel? Orders { get; set; }
    public ProductModel? Products { get; set; }
  }
}