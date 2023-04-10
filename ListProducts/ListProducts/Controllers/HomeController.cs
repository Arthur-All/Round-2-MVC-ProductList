using ListProducts.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interface;
using System.Diagnostics;

namespace ListProducts.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public  IActionResult Index()
        {
            var result =  _productService.GetAllProduct();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpGet]
        public JsonResult GetAllData()
        {
            var product = _productService.GetAllProduct();
            return Json(product);
        }
        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<Product>> GetAllProduct()
        {
            var result = await _productService.GetAllProduct();
            return View(result);
        }
    }
}