using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace api.EntityFramework{

        [Route("api/products")]
        [ApiController]
        public class ProductController : ControllerBase{
        private readonly ProductService _productService;
        public ProductController(AppDbContext appDbContext)
            {
                _productService=new ProductService(appDbContext) ;
            }


            [HttpGet]
        public IActionResult GetProducts()
        {
            try{
            var products  = _productService.GetProducts();
            return Ok(new SuccessResponse<List<Product>>{
                    Success=true,
                    Message="product are return successfully",
                    Data=products
                });}
            catch(Exception e)
            {
                Console.WriteLine("an error occured here when tried to get all products");
                return StatusCode(500,new ErrorResponse{
                Message = e.Message,
                Success=false,
            });
            }

        }
        [HttpPost]
        public IActionResult PostProduct(Product newProduct){
            
            try
            {
                 var newProducts=_productService.CreateNewProduct(newProduct);
                return Ok(newProducts);
            }
            catch (Exception ex){
                return StatusCode(500,ex.Message);
            }

            }
            [HttpPut ("{productId}")]

        public IActionResult UpdatepProduct(string productId, ProductModule updateProduct){
        if (!Guid. TryParse(productId, out Guid Id))

        return BadRequest("Invalid user ID Format");

        try
          {
            _productService.Updatedproductd(Id,updateProduct);
             return Ok("product Update successfully");
          }
             catch (Exception ex){

                   return StatusCode(500,ex.Message);
            }
        
         } 
         [HttpDelete ("{productId}")]

        public IActionResult deleteProduct(string productId){
        if(!Guid.TryParse(productId, out Guid Id ))
        {
        return BadRequest("Invalid product id format");
        }
        var res = _productService.deleteProduct(Id);
        if(!res){
            return NotFound();
        }
            return Ok(res);
        } 
        }}

        