using Microsoft.AspNetCore.Mvc;
using ShopApp.Core;
using ShopApp.Data.Concrete.EfCore;
using ShopApp.Entity.Concrete;
using ShopApp.WebUI.Areas.Admin.ViewModels;

namespace ShopApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        EfCoreCategoryRepository categoryRepository = new EfCoreCategoryRepository();
        //[HttpGet]
        public IActionResult Index(bool deletedStatus=false)
        {
            var categories = !deletedStatus ? categoryRepository.GetAllUndeletedCategories() : categoryRepository.GetAll();
            var categoriesViewModel = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                categoriesViewModel.Add(new CategoryViewModel
                {
                    Id= category.Id,
                    Name= category.Name,
                    Description= category.Description,
                    Url= category.Url,
                    IsDeleted=category.IsDeleted
                });
            }

            CategoryListViewModel categoryListViewModel = new CategoryListViewModel
            {
                CategoriesViewModel = categoriesViewModel,
                DeletedStatus = deletedStatus
            };
            return View(categoryListViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = categoryRepository.GetById(id);
            CategoryUpdateViewModel categoryUpdateViewModel = new CategoryUpdateViewModel()
            {
                Id= category.Id,
                Name=category.Name,
                Description=category.Description,
                Url= category.Url,
                UpdatedDate=category.UpdatedDate,
                IsApproved=category.IsApproved
            };

            return View(categoryUpdateViewModel);
        }
        [HttpPost]
        public IActionResult Edit(CategoryUpdateViewModel categoryUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = categoryRepository.GetById(categoryUpdateViewModel.Id);
                category.Name = categoryUpdateViewModel.Name;
                category.Description = categoryUpdateViewModel.Description;
                category.Url = Jobs.GetUrl(categoryUpdateViewModel.Name);
                category.IsApproved = categoryUpdateViewModel.IsApproved;
                category.UpdatedDate = DateTime.Now;
                categoryRepository.Update(category);

                return RedirectToAction("Index");
            }
            return View(categoryUpdateViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryAddViewModel categoryAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    Name = categoryAddViewModel.Name,
                    Description = categoryAddViewModel.Description,
                    Url = Jobs.GetUrl(categoryAddViewModel.Name),
                    IsApproved = categoryAddViewModel.IsApproved,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                categoryRepository.Create(category);
                return RedirectToAction("Index");
            }
            return View(categoryAddViewModel);
        }
        
        public IActionResult Delete(int id)
        {
            Category deletedCategory = categoryRepository.GetById(id);
            if (deletedCategory!=null)
            {
                categoryRepository.Delete(deletedCategory);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            //Silinecek kategori bilgilerini gösteren sayfayı getirecek
            Category removedCategory = categoryRepository.GetById(id);
            if (removedCategory!=null)
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel
                {
                    Id = removedCategory.Id,
                    Name = removedCategory.Name,
                    Description = removedCategory.Description
                };
                return View(categoryViewModel);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Remove(CategoryUpdateViewModel categoryUpdateViewModel)
        {
            Category category = categoryRepository.GetById(categoryUpdateViewModel.Id);
            if (category != null)
            {
                category.IsDeleted = true;
                categoryRepository.Update(category);
            }
            return RedirectToAction("Index");
        }

        public IActionResult CheckStatus(string checkStatus)
        {
            // eğğer checkstatus true ise tümünü göster, değil ise silinmemişleri
            if (checkStatus!=null)
            {
                return RedirectToAction("ShowAllCategories");
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public IActionResult ShowAllCategories()
        {
            var categories = categoryRepository.GetAll();
            var categoriesViewModel = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                categoriesViewModel.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    Url = category.Url,
                    IsDeleted = category.IsDeleted
                });
            }
            return View("Index",categoriesViewModel);
        }
        
    }
}
