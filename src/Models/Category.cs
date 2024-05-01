using System.ComponentModel.DataAnnotations;

public class Category
{
  public Guid CategoryId { get; set; }
  
  [Required(ErrorMessage = "Category name is requierd")]
  [MinLength(2, ErrorMessage = "Category name must be at least 2 characters long.")]
  [MaxLength(50, ErrorMessage = "Category name must be at most 50 characters long.")]
  public string Name { get; set; }
  public string Slug { get; set; }= string.Empty;

  [MaxLength(300, ErrorMessage = "Description can be at most 300 characters long.")]
  public string Description { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
}

