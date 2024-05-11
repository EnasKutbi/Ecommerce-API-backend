<<<<<<< HEAD
// using api.EntityFramework;
// using api.Models;
=======
using api.EntityFramework;
using api.Models;
using Microsoft.EntityFrameworkCore;
>>>>>>> 7636f781c269c3b30565bcfe0a24518d7a6931e8

// namespace api.Services
// {
//   public class OrderItemService
//   {
//     private readonly AppDbContext _appDbContext;

//     public OrderItemService(AppDbContext appDbContext)
//     {
//       _appDbContext = appDbContext;
//     }

<<<<<<< HEAD
//     public async Task<OrderItem> AddOrderItemService(Guid orderId, OrderItemModel newOrderItemModel)
//     {
//       var orderItem = new OrderItem
//       {
        
//         OrderId = orderId,
//         ProductId = newOrderItemModel.ProductId,
        
//       };
=======
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
>>>>>>> 7636f781c269c3b30565bcfe0a24518d7a6931e8

//       await _appDbContext.OrderItems.AddAsync(orderItem);
//       await _appDbContext.SaveChangesAsync();

<<<<<<< HEAD
//       return orderItem;
//     }
//   }
// }
=======
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
>>>>>>> 7636f781c269c3b30565bcfe0a24518d7a6931e8
