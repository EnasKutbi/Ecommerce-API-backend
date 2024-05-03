using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class OrderModel
    {
        [Required] // validation
        public Guid OrderId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public required string OrderStatus { get; set; }
        [Required]
        public int OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
    }
}