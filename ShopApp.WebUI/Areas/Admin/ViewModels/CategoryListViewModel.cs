using System.ComponentModel;

namespace ShopApp.WebUI.Areas.Admin.ViewModels
{
    public class CategoryListViewModel
    {
        public List<CategoryViewModel> CategoriesViewModel { get; set; }
        [DisplayName("Tümünü Göster")]
        public bool DeletedStatus { get; set; }
    }
}
