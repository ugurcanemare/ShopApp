namespace ShopApp.WebUI.Areas.Admin.ViewModels
{
    public class ProductListViewModel
    {
        public List<ProductViewModel> ProductsViewModel { get; set; }
        public bool DeletedStatus { get; set; }
        public bool ApprovedStatus { get; set; }
        public bool HomeStatus { get; set; }
    }
}
