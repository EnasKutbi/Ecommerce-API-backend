using api.EntityFramework;

namespace api.Models
{
  public class OrderItemModel
  {
    public Guid OrderItemId { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    //Relations M-M between Orders and Products
    public Order? Orders { get; set; }
    public Product? Products { get; set; }
  }
}