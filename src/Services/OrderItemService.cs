using api.EntityFramework;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
  public class OrderItemService
  {
    private readonly AppDbContext _appDbContext;

    public OrderItemService(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<OrderItem>> GetAllOrderItem()
    {
        return await _appDbContext.OrderItems
        .Include(p => p.Product)
        .Include(o => o.Order)
        .ToListAsync();
    }
    public async Task<OrderItem?> GetOrderItemById(Guid orderItemId)
    {
        return await _appDbContext.OrderItems
        .Include(p => p.Product)
        .Include(o => o.Order)
        .FirstOrDefaultAsync(orderItem => orderItem.OrderItemId == orderItemId);
    }
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
    public async Task<OrderItem?> UpdateOrderItem(Guid orderItemId, OrderItem updateOrderItem)
    {
        var existingOrderItem = _appDbContext.OrderItems.FirstOrDefault(orderItem => orderItem.OrderItemId == orderItemId);
        if (existingOrderItem != null)
            {
                existingOrderItem.Quantity = updateOrderItem.Quantity;
    
            }
            await _appDbContext.SaveChangesAsync();
            return existingOrderItem;
        }
        public async Task<bool> DeleteOrderItem(Guid orderItemId)
        {
            var orderItemsToRemove = _appDbContext.OrderItems.FirstOrDefault(orderItem => orderItem.OrderItemId == orderItemId);
            if (orderItemsToRemove != null)
            {
                _appDbContext.OrderItems.Remove(orderItemsToRemove);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    
  }
}