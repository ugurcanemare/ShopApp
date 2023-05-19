using Microsoft.AspNetCore.Mvc;
using ShopApp.Data.Concrete.EfCore;
using ShopApp.Entity.Concrete;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.Models.ViewModels;
using System.Diagnostics;

namespace ShopApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        EfCoreProductRepository productRepository = new EfCoreProductRepository();
        public IActionResult Index()
        {
            List<Product> products = productRepository.GetHomePageProducts();
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (Product product in products)
            {
                productViewModels.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Url=product.Url
                });
            }
            return View(productViewModels);
        }

    }
}