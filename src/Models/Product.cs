using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.AspNetCore.Mvc;

public class Product{

    public Guid Id { get; set;}
    [Required(ErrorMessage = "Product name is required!")]
    public  string Name { get; set;}
    public required string Slug { get; set;}
    public string ImageUrl { get; set;}=string.Empty;
    public string Description { get; set;}=string.Empty;
    public required double Price { get; set;}
    public  int Quantity { get; set;}
    public  int Sold{ get; set;}
    public double shipping { get; set;}
    public Guid category_id{ get; set;}
    // public CategoryAttribute? category { get; set;}
    public DateTime CreatedAt {get; set;}}



    

    












        
