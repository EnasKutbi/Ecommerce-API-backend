using api.EntityFramework;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  [Route("api/OrderItem")]
  public class OrderItemController : ControllerBase
  {
    private readonly OrderItemService _orderItemService;

    public OrderItemController(AppDbContext appDbContext)
    {
      _orderItemService = new OrderItemService(appDbContext);
    }


    [HttpGet]
        public async Task<IActionResult> GetAllOrderItem()
        {
            try
            {
                var orderItem = await _orderItemService.GetAllOrderItem();
                if (orderItem.ToList().Count <= 0)
                {
                    return NotFound(new ErrorResponse { Message = "There is no orderItems to display" });
                }
                else
                {
                    return Ok(new SuccessResponse<IEnumerable<OrderItem>>
                    {
                      Message = "Order Items are returned successfully",
                      Data = orderItem
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not return the Order Item list");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }

        }

        [HttpGet("{orderItemId}")]
        public async Task<IActionResult> GetOrderItemById(Guid orderItemId)
        {
            try
            {

                var orderItem = await _orderItemService.GetOrderItemById(orderItemId);
                if (orderItem == null)
                {
                    return NotFound(new ErrorResponse { Message = $"There is no order item found with ID : {orderItemId}" });
                }
                else
                {
                    return Ok(new SuccessResponse<OrderItem>
                    {
                        Message = "Order Item is returned successfully",
                        Data = orderItem
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not return the Order Item");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddOrderItem(Guid orderId, OrderItemModel newOrderItemModel)
    {
      try
      {
        var orderItem = await _orderItemService.AddOrderItemService(orderId, newOrderItemModel);
        return Ok(new SuccessResponse<OrderItem>{Message = "Order Item is created successfully"});
      }
      catch (Exception ex)
            {
                Console.WriteLine($"There is an error");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
    }
        


        [HttpPut("{orderItemId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateOrderItem(Guid orderItemId, OrderItem updateOrderItem)
        {
            try
            {

                var orderItem = await _orderItemService.UpdateOrderItem(orderItemId, updateOrderItem);
                if (orderItem == null)
                {
                    return NotFound(new ErrorResponse { Message = "There is no order Item found to update." });
                }
                else
                {
                    return Ok(new SuccessResponse<OrderItem>
                    {
                        Message = "Order Item is updated  succeefully",
                        Data = orderItem
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not update the order Item");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
        }


        [HttpDelete("{orderItemId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteOrderItem(Guid orderItemId)
        {
            try
            {

                var result = await _orderItemService.DeleteOrderItem(orderItemId);
                if (!result)
                {
                    return NotFound(new ErrorResponse { Message = $"The order Item with ID : {orderItemId} is not found to be deleted" });
                }
                else
                {
                    return Ok(new SuccessResponse<OrderItem>
                    {
                        Message = "Order Item is deleted succeefully",
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not delete the order Item ");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }

        }

    
  }
}