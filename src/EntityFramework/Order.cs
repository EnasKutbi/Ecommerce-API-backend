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
        public required string OrderStatus { get; set; }
        [Required]
        public int OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
    }
}