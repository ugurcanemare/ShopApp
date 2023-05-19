using Microsoft.AspNetCore.Mvc;
using ShopApp.Data.Concrete.EfCore;
using ShopApp.Entity.Concrete;
using ShopApp.WebUI.Models.ViewModels;

namespace ShopApp.WebUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categoryRepository = new EfCoreCategoryRepository();
            List<Category> categories = categoryRepository.GetAll();
            List<CategoryViewModel>  categoriesViewModel = new List<CategoryViewModel>();
            foreach (Category category in categories)
            {
                categoriesViewModel.Add(new CategoryViewModel
                {
                    Id=category.Id,
                    Name=category.Name,
                    Description=category.Description,
                    Url=category.Url
                });
            }
            return View(categoriesViewModel);
        }
    }
}
