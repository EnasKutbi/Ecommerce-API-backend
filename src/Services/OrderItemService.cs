using api.EntityFramework;
using api.Models;

namespace api.Services
{
  public class OrderItemService
  {
    private readonly AppDbContext _appDbContext;

    public OrderItemService(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    // add orderProduct
    public async Task<OrderItem> AddOrderItemService(Guid orderId, OrderItemModel newOrderItemModel)
    {
      var orderItem = new OrderItem
      {
        OrderItemId = Guid.NewGuid(),
        OrderId = orderId,
        ProductId = newOrderItemModel.ProductId,
        Quantity = newOrderItemModel.Quantity,
      };

      await _appDbContext.OrderItems.AddAsync(orderItem);
      await _appDbContext.SaveChangesAsync();

      return orderItem;
    }
  }
}