using Microsoft.AspNetCore.Mvc;
using ShopApp.Core;
using ShopApp.Data.Concrete.EfCore;
using ShopApp.Entity.Concrete;
using ShopApp.WebUI.Areas.Admin.ViewModels;

namespace ShopApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        EfCoreProductRepository productRepository = new EfCoreProductRepository();
        EfCoreCategoryRepository categoryRepository = new EfCoreCategoryRepository();
        public IActionResult Index(bool DeletedStatus = false)
        {
            List<Product> products = !DeletedStatus ? productRepository.GetAllUndeletedProducts() : productRepository.GetAll();
            List<ProductViewModel> productsViewModel = new List<ProductViewModel>();
            #region Ürünleri Foreach ile çekmek
            //foreach (var p in products)
            //{
            //    productsViewModel.Add(new ProductViewModel
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        Description = p.Description,
            //        Url = p.Url,
            //        Price = p.Price,
            //        ImageUrl = p.ImageUrl,
            //        IsHome = p.IsHome,
            //        IsApproved = p.IsApproved,
            //        IsDeleted = p.IsDeleted,
            //        CreatedDate = p.CreatedDate,
            //        UpdatedDate = p.UpdatedDate
            //    });
            //}
            #endregion

            #region Ürünleri Linq ile çekmek
            productsViewModel = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Url = p.Url,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                IsHome = p.IsHome,
                IsApproved = p.IsApproved,
                IsDeleted = p.IsDeleted,
                CreatedDate = p.CreatedDate,
                UpdatedDate = p.UpdatedDate
            }).ToList();
            #endregion

            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                ProductsViewModel = productsViewModel,
                DeletedStatus = DeletedStatus,
            };
            return View(productListViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<Category> categories = categoryRepository.GetAllUndeletedCategories();
            ProductAddViewModel productAddViewModel = new ProductAddViewModel
            {
                Categories = categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            };
            return View(productAddViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductAddViewModel productAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    Name = productAddViewModel.Name,
                    Description = productAddViewModel.Description,
                    Url = Jobs.GetUrl(productAddViewModel.Name),
                    Price = productAddViewModel.Price,
                    IsHome = productAddViewModel.IsHome,
                    IsApproved = productAddViewModel.IsApproved,
                    ImageUrl = Jobs.UploadImage(productAddViewModel.ImageFile)
                };
                productRepository.CreateProductWithCategories(product, productAddViewModel.SelectedCategories);
                return RedirectToAction("Index");
            }
            List<Category> categories = categoryRepository.GetAllUndeletedCategories();
            productAddViewModel.Categories = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return View(productAddViewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = productRepository.GetProductWithCategories(id);
            List<Category> categories = categoryRepository.GetAllUndeletedCategories();
            List<CategoryViewModel> categoriesViewModel = new List<CategoryViewModel>();
            ProductUpdateViewModel productUpdateViewModel = new ProductUpdateViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsHome = product.IsHome,
                IsApproved = product.IsApproved,
                IsDeleted = product.IsDeleted,
                UpdatedDate = product.UpdatedDate,
                ImageUrl = product.ImageUrl,
                ImageFile = null,
                Url = product.Url,
                Categories = categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                SelectedCategories = product
                    .ProductCategories
                    .Select(pc => pc.CategoryId)
                    .ToArray()
            };
            return View(productUpdateViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductUpdateViewModel productUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = productRepository.GetById(productUpdateViewModel.Id);
                if (product != null)
                {
                    product.Name = productUpdateViewModel.Name;
                    product.Description = productUpdateViewModel.Description;
                    product.Price = productUpdateViewModel.Price;
                    product.IsHome = productUpdateViewModel.IsHome;
                    product.IsApproved = productUpdateViewModel.IsApproved;
                    product.IsDeleted = productUpdateViewModel.IsDeleted;
                    product.UpdatedDate = productUpdateViewModel.UpdatedDate;
                    product.Url = Jobs.GetUrl(productUpdateViewModel.Name);
                    if (productUpdateViewModel.ImageFile != null)
                    {
                        product.ImageUrl = Jobs.UploadImage(productUpdateViewModel.ImageFile);
                    }
                    productRepository.UpdateProductWithCategories(product, productUpdateViewModel.SelectedCategories);
                    return RedirectToAction("Index");
                }

            }
            List<Category> categories = categoryRepository.GetAllUndeletedCategories();
            productUpdateViewModel.Categories = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return View(productUpdateViewModel);
        }
        public IActionResult Delete(int id)
        {
            Product product = productRepository.GetById(id);
            if (product != null)
            {
                productRepository.Delete(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            Product product = productRepository.GetById(id);
            if (product != null)
            {
                product.IsDeleted = true;
                productRepository.Update(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateIsHome(int id)
        {
            Product product = productRepository.GetById(id);
            if (product != null)
            {
                product.IsHome = !product.IsHome;
                productRepository.Update(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateIsApproved(int id)
        {
            Product product = productRepository.GetById(id);
            if (product != null)
            {
                product.IsApproved = !product.IsApproved;
                productRepository.Update(product);
            }
            return RedirectToAction("Index");
        }

    }
}
