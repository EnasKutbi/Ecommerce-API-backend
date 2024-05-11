using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Model;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{

    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(AppDbContext appDbContext)
        {
            _productService = new ProductService(appDbContext);
        }


        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {

            var users = await _productService.GetProducts();
            return ApiResponse.Success(users, "All Users are returned successfully");

        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory(Guid ProductId)
        {
            try
            {

                var ProductById = await _productService.GetProductById(ProductId);
                if (ProductById == null)
                {
                    return NotFound(new ErrorResponse { Message = $"There is no category found with ID : {ProductId}" });
                }
                else
                {
                    return ApiResponse.Success(ProductById, "All Users are returned successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not return the category");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }}
       [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel newProduct)
        {
             
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid User Data");
            }


            var newUser = await _productService.CreateProductService(newProduct);
            return ApiResponse.Created(newUser, "User created successfully");

        }
        [HttpPost("AddOrderItem")]
         public async Task<IActionResult> AddProdetOrder([FromQuery] Guid ProductId ,  [FromQuery]Guid OrderId ){
         try
         {
            await _productService.AddProdetOrder(ProductId,OrderId);
            return ApiResponse.Created("created");
         }
         catch(Exception ex)
         {
           return ApiResponse.ServerError(ex.Message);

<<<<<<< HEAD
         }}
         
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateProduct(Guid ProductId, ProductModel updateProduct)
=======
        public IActionResult UpdatepProduct(string productId, ProductModel updateProduct)
>>>>>>> 7636f781c269c3b30565bcfe0a24518d7a6931e8
        {
            try
            {

                var product = await _productService.UpdateProductService(ProductId, updateProduct);
                if (product == null)
                {
                    return NotFound(new ErrorResponse { Message = "There is no Product found to update." });
                }
                else
                {
                    return ApiResponse.Success(product, "All Users are returned successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not update the category");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
        }
        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteProduct(Guid ProductId)
        {
            try
            {

                var result = await _productService.DeleteProductService(ProductId);
                if (!result)
                {
                    return NotFound(new ErrorResponse { Message = $"The category with ID : {ProductId} is not found to be deleted" });
                }
                else
                {
                    return Ok(new SuccessResponse<Product>
                    {
                        Message = "Product is deleted succeefully",
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not delete the category");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }

        }

}}