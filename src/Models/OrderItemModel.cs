using System.ComponentModel.DataAnnotations;
using api.EntityFramework;
using api.Model;

namespace api.Models
{
  public class OrderItemModel
  {
    public Guid OrderItemId { get; set; }
    public Guid OrderId { get; set; }//Foreign Key
    public Guid ProductId { get; set; }//Foreign Key
    
    [Required]
    public int Quantity { get; set; }

    //Relations M-M between Orders and Products
    public OrderModel? Orders { get; set; }
    public ProductModel? Products { get; set; }
  }
}