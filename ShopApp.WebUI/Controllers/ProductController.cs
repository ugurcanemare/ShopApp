using Microsoft.AspNetCore.Mvc;
using ShopApp.Data.Concrete.EfCore;
using ShopApp.Entity.Concrete;
using ShopApp.WebUI.Models.ViewModels;

namespace ShopApp.WebUI.Controllers
{
    public class ProductController : Controller
    {
        EfCoreProductRepository productRepository = new EfCoreProductRepository();
        public IActionResult Index()
        {
            List<Product> products = productRepository.GetAll();
            List<ProductViewModel> productViewModels= new List<ProductViewModel>();
            foreach (Product product in products)
            {
                productViewModels.Add(new ProductViewModel
                {
                    Id=product.Id,
                    Name=product.Name,
                    Price=product.Price,
                    Description=product.Description,
                    ImageUrl=product.ImageUrl,
                    Url=product.Url
                });
            }
            return View(productViewModels);
        }
        public IActionResult ProductDetails(string producturl)
        {
            Product product = productRepository.GetProductDetailsByUrl(producturl);
            if (product == null)
            {
                return NotFound();
            }

            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Url = product.Url,
                Categories = product
                            .ProductCategories
                            .Select(pc => pc.Category)
                            .ToList()

            };
            return View(productDetailsViewModel);
        }
    }
}
