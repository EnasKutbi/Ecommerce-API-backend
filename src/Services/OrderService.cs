using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class OrderService
    {
        private AppDbContext _appDbContext;
        public OrderService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        ////// Get All
        // public async Task<IEnumerable<Order>> GetAllOrders()
        // {
        //     return await _appDbContext.Orders.ToListAsync();
        // }

        public async Task<PaginationDto<Order>> GetAllOrders(QueryParameters queryParams)
        {
            // Start with a base query
            var query = _appDbContext.Orders.Include(o => o.User).AsQueryable();

            // Apply search keyword filter
            if (!string.IsNullOrEmpty(queryParams.SearchKeyword))
            {
                query = query.Where(p => p.OrderStatus.ToLower().Contains(queryParams.SearchKeyword.ToLower()));
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(queryParams.SortBy))
            {
                query = queryParams.SortOrder == "desc"
                ? query.OrderByDescending(u => EF.Property<object>(u, queryParams.SortBy))
                : query.OrderBy(u => EF.Property<object>(u, queryParams.SortBy));
            }

            var totalOrderCount = await query.CountAsync();

            var orders = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .ToListAsync();
            return new PaginationDto<Order>
            {
                Items = orders,
                TotalCount = totalOrderCount,
                PageNumber = queryParams.PageNumber,
                PageSize = queryParams.PageSize
            };
        }

        //////// Get By ID
        public async Task<Order?> GetOrderById(Guid orderId)
        {
            return await _appDbContext.Orders.Include(o => o.User).FirstOrDefaultAsync(order => order.OrderId == orderId);
        }

        ////// Post
        public async Task<Order> PostOrder(Order newOrder)
        {
            newOrder.OrderId = Guid.NewGuid();
            newOrder.OrderDate = DateTime.UtcNow;
            _appDbContext.Orders.Add(newOrder); // add record to context
            await _appDbContext.SaveChangesAsync(); // save to DB
            return newOrder;
        }

        //////// Update
        public async Task<Order?> PutOrder(Guid orderId, Order putOrder)
        {
            var existingOrder = _appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (existingOrder != null)
            {
                existingOrder.OrderStatus = putOrder.OrderStatus;
                existingOrder.OrderTotal = putOrder.OrderTotal;
            }
            await _appDbContext.SaveChangesAsync();
            return existingOrder;
        }

        /////// Delete
        public async Task<bool> DeleteOrder(Guid orderId)
        {
            var OrderToRemove = _appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (OrderToRemove != null)
            {
                _appDbContext.Orders.Remove(OrderToRemove);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}