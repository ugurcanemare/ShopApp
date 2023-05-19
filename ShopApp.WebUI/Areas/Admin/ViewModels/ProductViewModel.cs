using ShopApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Areas.Admin.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        [DisplayFormat(ApplyFormatInEditMode =false,DataFormatString ="{0:c}")]
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; } = true;
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<Category> Categories { get; set; }

    }
}
