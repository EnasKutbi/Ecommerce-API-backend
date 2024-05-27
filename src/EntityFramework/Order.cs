using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.EntityFramework
{
    [Table("Orders")]
    public class Order
    {
        [Key, Required] // validation
        public Guid OrderId { get; set; }
        [Required]
        public Guid UserId { get; set; }// Foreign Key

        [Required]
        [MaxLength(30)]
        public string OrderStatus { get; set; } = "processing";
        [Required]
        public int OrderTotal { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        //Relationships
        public User? User { get; set; } // get User Entity
        public ICollection<OrderItem> OrderItems { get; set; } // for M-M with product
    }
}