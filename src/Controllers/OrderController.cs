using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Model;
using api.Service;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(AppDbContext appDbContext) {
            _orderService = new OrderService(appDbContext);
        }
        [HttpGet]
        public IActionResult GetOrders() {
            try
            {
                var orders = _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception e)
            {
                 return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult PostOrder(OrderModel newOrder) {
            try
            {
                _orderService.PostOrder(newOrder);
                return Ok("Order Created Successfully");
            }
            catch (Exception e)
            {
                 return BadRequest(e.Message);
            }
        }
        [HttpPut("{orderId}")]
        public IActionResult PutOrder(Guid orderId, OrderModel putorder) {
            try
            {
                _orderService.PutOrder(orderId, putorder);
                return Ok("Order Updated Successfully");
            }
            catch (Exception e)
            {
                 return BadRequest(e.Message);
            }
        }
        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder(Guid orderId) {
            try
            {
                _orderService.DeleteOrder(orderId);
                return Ok("Order Created Successfully");
            }
            catch (Exception e)
            {
                 return BadRequest(e.Message);
            }
        }
    }
}