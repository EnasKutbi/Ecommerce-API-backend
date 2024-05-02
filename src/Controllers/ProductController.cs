using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{

        [Route("api/products")]
        [ApiController]
        public class ProductController : ControllerBase{
        private readonly ProductService _productService;
        public ProductController()
            {
                _productService=new ProductService() ;
            }
        
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products  = _productService.GetAllProduct();
            return Ok(products);
        }
        [HttpGet("{productId}")]
        public IActionResult GetProductById(string productId)
        {
            if(!Guid.TryParse(productId, out Guid Id )){
                return BadRequest("Invalid product id format");

            }
            var product  = _productService.GetProductById(Id);
            if(product == null){
                return NotFound();
            }else{
                return Ok(product);
            }
        }
        [HttpPost]
        public IActionResult PostProduct(Product newProduct){
            var newProducts=_productService.CreateNewProduct(newProduct);
            return CreatedAtAction (nameof (GetProductById), new{ Id =newProducts.Id});   
        }

        [HttpPut ("{productId}")]

        public IActionResult UpdatepProduct(string productId, Product updateProduct){
        if (!Guid. TryParse(productId, out Guid Id))

        return BadRequest("Invalid user ID Format");

        var product =  _productService.UpdateProduct(Id, updateProduct);

        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
        }
        
        [HttpDelete ("{productId}")]

        public IActionResult deleteProduct(string productId){
        if(!Guid.TryParse(productId, out Guid Id ))
        {
        return BadRequest("Invalid product id format");
        }
        var res = _productService.deleteProductById(Id);
        if(!res){
            return NotFound();
        }
            return NoContent();
        }
        
        }  }
   
    
        
    