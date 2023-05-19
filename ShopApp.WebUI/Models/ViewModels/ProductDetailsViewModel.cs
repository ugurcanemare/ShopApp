using ShopApp.Entity.Concrete;

namespace ShopApp.WebUI.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public List<Category> Categories { get; set; }
    }
}
