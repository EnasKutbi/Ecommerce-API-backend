using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using api.Services;
using api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(AppDbContext appDbContext)
        {
            _orderService = new OrderService(appDbContext);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                if (orders.ToList().Count <= 0)
                {
                    return NotFound(new ErrorResponse { Message = "There is no orders to display" });
                }
                else
                {
                    return Ok(new SuccessResponse<IEnumerable<Order>>
                    {
                        Message = "Orders are returned successfully",
                        Data = orders
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not return the order list");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
        }

        /// Get By ID
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            try
            {

                var order = await _orderService.GetOrderById(orderId);
                if (order == null)
                {
                    return NotFound(new ErrorResponse { Message = $"There is no order found with ID : {orderId}" });
                }
                else
                {
                    return Ok(new SuccessResponse<Order>
                    {
                        Message = "Category is returned successfully",
                        Data = order
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not return the order");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }

        }

        /// Post
        [HttpPost]
        public async Task<IActionResult> PostOrder(Order newOrder)
        {
            try
            {
                var createdOrder = await _orderService.PostOrder(newOrder);
                if (createdOrder == null)
                {
                    return NotFound(new ErrorResponse { Message = $"There is no order entered !" });
                }
                else
                {
                    return Ok(new SuccessResponse<Order>
                    {
                        Message = "Order is created successfully",
                        Data = createdOrder
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not create new category");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
        }
        /// Put
        [HttpPut("{orderId}")]
        public async Task<IActionResult> PutOrder(Guid orderId, Order putOrder)
        {
            try
            {

                var order = await _orderService.PutOrder(orderId, putOrder);
                if (order == null)
                {
                    return NotFound(new ErrorResponse { Message = "There is no order found to update." });
                }
                else
                {
                    return Ok(new SuccessResponse<Order>
                    {
                        Message = "Order is updated  successfully",
                        Data = order
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not update the order");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
        }
        /// DElete
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            try
            {

                var result = await _orderService.DeleteOrder(orderId);
                if (!result)
                {
                    return NotFound(new ErrorResponse { Message = $"The order with ID : {orderId} is not found to be deleted" });
                }
                else
                {
                    return Ok(new SuccessResponse<Order>
                    {
                        Message = "Order is deleted successfully",
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not delete the order");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }

        }
    }
}