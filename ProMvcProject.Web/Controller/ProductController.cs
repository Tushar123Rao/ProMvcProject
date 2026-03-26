using Microsoft.AspNetCore.Mvc;
using ProMvcProject.Web.Services;

namespace ProMvcProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAvailableProductsAsync();
            // This method looks for a file named Index.cshtml 
            // inside the Views/Product/ folder
            return View(products);
        }
    }
}
