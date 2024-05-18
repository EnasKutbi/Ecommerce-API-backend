using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(AppDbContext appDbContext)
        {
            _productService = new ProductService(appDbContext);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 3)
        {
            var products = await _productService.GetProducts(pageNumber, pageSize);
            return ApiResponse.Success(products, "All products are returned successfully");
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            try
            {

                var product = await _productService.GetProductById(productId);
                if (product == null)
                {
                    return NotFound(new ErrorResponse { Message = $"There is no Product found with ID : {productId}" });
                }
                else
                {
                    return Ok(new SuccessResponse<Product> { Success = true, Message = "product is returned successfully", Data = product });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not return the Product");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct(Product newProduct)
        {
            try
            {
                Guid categoryId = newProduct.CategoryId;
                var createdProduct = await _productService.CreateProductService(newProduct, categoryId);
                if (createdProduct != null)
                {
                    return CreatedAtAction(nameof(GetProduct), new { productId = createdProduct.ProductId }, createdProduct);
                }
                else
                {
                    return Ok(new SuccessResponse<Product>
                    {
                        Message = "Product is created successfully",
                        Data = createdProduct
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"product can not be created");
                return StatusCode(500, new ErrorResponse { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductService(Guid productId, Product updateProduct)
        {
            try
            {

                var product = await _productService.UpdateProductService(productId, updateProduct);
                if (product == null)
                {
                    return NotFound(new ErrorResponse { Message = "There is no product found to update." });
                }
                else
                {
                    return Ok(new SuccessResponse<Product> { Success = true, Message = "product is updated successfully", Data = product });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not update the product");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }
        }
        [HttpDelete("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            try
            {
                var result = await _productService.DeleteProductService(productId);
                if (!result)
                {
                    return NotFound(new ErrorResponse { Message = $"The Product with ID : {productId} is not found to be deleted" });
                }
                else
                {
                    return Ok(new SuccessResponse<Product>
                    {
                        Message = "Product is deleted successfully",
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is an error , can not delete the Product");
                return StatusCode(500, new ErrorResponse { Message = ex.Message });
            }

        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("Keyword is required for search.");
            }

            var products = await _productService.SearchProductsAsync(keyword);
            return Ok(products);
        }

    }
}