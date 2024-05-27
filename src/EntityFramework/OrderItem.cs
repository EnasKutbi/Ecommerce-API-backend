using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.EntityFramework
{
  [Table("OrderItem")]
  public class OrderItem
  {
    [ForeignKey("OrderId")]
    public Guid OrderId { get; set; }

    [ForeignKey("ProductId")]
    public Guid ProductId { get; set; }
  }
}