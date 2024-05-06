using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Model;

namespace api.Service
{
    public class OrderService
    {
        private AppDbContext _appDbContext;
        public OrderService(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }
        public IEnumerable<OrderModel> GetAllOrders() {
            List<OrderModel> orders = new List<OrderModel>();
            var datalist = _appDbContext.Orders.ToList();
            datalist.ForEach(row => orders.Add(new OrderModel {
                OrderId = row.OrderId,
                UserId = row.UserId,
                OrderStatus = row.OrderStatus,
                OrderTotal = row.OrderTotal,
                OrderDate = DateTime.Now,
            }));
            return orders;
        }
        public void PostOrder(OrderModel newOrder) {
            var order = new Order { // create the record
                OrderId = Guid.NewGuid(),
                UserId = newOrder.UserId,
                OrderStatus = newOrder.OrderStatus,
                OrderTotal = newOrder.OrderTotal,
                OrderDate = DateTime.Now,
            };
            _appDbContext.Orders.Add(order); // add record to context
            _appDbContext.SaveChanges(); // save to DB
        }
        public void PutOrder(Guid orderId, OrderModel putorder) {
            var order = _appDbContext.Orders.FirstOrDefault(order =>
            order.OrderId == orderId);
            if (order != null) {
            order.OrderStatus = putorder.OrderStatus;
            order.OrderTotal = putorder.OrderTotal;
            _appDbContext.SaveChanges();
            } 
        }
        public void DeleteOrder(Guid orderId) {
            var order = _appDbContext.Orders.FirstOrDefault(order =>
            order.OrderId == orderId);
            if (order != null) {
                _appDbContext.Orders.Remove(order); 
            _appDbContext.SaveChanges();
            } 
        }
    }
}