using ListProducts.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interface;


namespace ProductList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        #region Get
        [HttpGet("GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int Id)
        {
            var result = await _productService.GetProductById(Id);
            return Ok(result);
        }

        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<Product>> GetAllProduct()
        {
            var result = await _productService.GetAllProduct();
            return Ok(result);
        }

        [HttpGet("GetProductByName")]
        public async Task<ActionResult<Product>> GetProductByName(string productName)
        {
            var result = await _productService.GetProductByName(productName);
            return Ok(result);
        }

        [HttpGet("GetCartProduct")]
        public async Task<ActionResult<Product>> GetCartProduct()
        {
            var result = await _productService.GetCartProduct();
            return Ok(result);
        }

        #endregion

        #region Create,Update,Delete
        [HttpPost("CreateProduct")]
        public async Task<ActionResult<bool>> CreateProduct([FromBody] Product product)
        {
            await _productService.CreateProduct(product);
            return Ok("Product has been added");
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] Product product)
        {
            await _productService.UpdateProduct(product);
            return Ok("Product has been updated");
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok("Product has been deleted");
        }
        [HttpPut("AddInCart/{id}")]
        public async Task<ActionResult<bool>> AddInCart(int id)
        {
            await _productService.AddInCart(id);
            return Ok("Product has been add in cart");
        }
        #endregion
    }
}
