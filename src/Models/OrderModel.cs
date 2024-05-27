using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Models
{
    public class OrderModel
    {
        [Required] // validation
        public Guid OrderId { get; set; }
        [Required]
        public Guid UserId { get; set; } // foreign key to users table
        [Required]
        public string OrderStatus { get; set; } = "processing";
        [Required]
        public int OrderTotal { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public UserModel? User { get; set; } // 1-1 relation

        //Relation M-M between Orders and Products
        public ICollection<OrderItemModel>? OrderItems { get; set; }
    }
}