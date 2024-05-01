using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        public OrderController() {}
        [HttpGet]
        public IActionResult GetOrder() {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                 return BadRequest(e.Message);
            }
        }
    }
}