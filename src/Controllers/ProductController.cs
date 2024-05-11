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

            var Product = await _productService.GetProducts();
            return ApiResponse.Success(Product, "All Users are returned successfully");

        }

        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProduct(Guid ProductId)
        {
            try
            {

                var ProductById = await _productService.GetProductById(ProductId);
                if (ProductById == null)
                {
                    return NotFound(new ErrorResponse { Message = $"There is no Product found with ID : {ProductId}" });
                }
                else
                {
                    return ApiResponse.Success(ProductById, "All Product are returned successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not return the Product");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }}
       [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel NewProduct)
        {
             
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid User Data");
            }


            var newProduct = await _productService.CreateProductService(NewProduct);
            return ApiResponse.Created(newProduct, "User created successfully");

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
         
        [HttpPut("{ProductId}")]
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
                    return ApiResponse.Success(product, "All Product are returned successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not update the Products");
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
                    return NotFound(new ErrorResponse { Message = $"The Product with ID : {ProductId} is not found to be deleted" });
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
                Console.WriteLine($"There is an error , can not delete the Product");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }

        }

}}