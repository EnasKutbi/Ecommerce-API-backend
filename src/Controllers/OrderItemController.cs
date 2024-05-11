// using api.EntityFramework;
// using api.Models;
// using api.Services;
// using Microsoft.AspNetCore.Mvc;

// namespace api.Controllers
// {
//   [ApiController]
//   [Route("api/orderProducts")]
//   public class OrderItemController : ControllerBase
//   {
//     private readonly OrderItemService _orderItemService;

//     public OrderItemController(AppDbContext appDbContext)
//     {
//       _orderItemService = new OrderItemService(appDbContext);
//     }


//     [HttpPost]
//     public async Task<IActionResult> AddOrderItem(Guid orderId, OrderItemModel newOrderItemModel)
//     {
//       try
//       {
//         var orderItem = await _orderItemService.AddOrderItemService(orderId, newOrderItemModel);
//         return Ok(new SuccessResponse<Category>{Message = "Order Item is created successfully"});
//       }
//       catch (Exception ex)
//             {
//                 Console.WriteLine($"There is an error");
//                 return StatusCode(500, new ErrorResponse { Message = ex.Message });
//             }
//     }
//   }
// }