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
        public Guid UserId { get; set; }
        public User User { get; set; } // get User Entity
        [Required]
        [MaxLength(30)]
        public required string OrderStatus { get; set; }
        [Required]
        public int OrderTotal { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        //[Required]
        //public Guid ProductId { get; set; }
        //public Product Product { get; set; } // get Product Entity
    }
}