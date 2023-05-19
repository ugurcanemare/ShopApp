using ShopApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Areas.Admin.ViewModels
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "Ürün Adı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Ürün Adı En az 5 karakter olmalıdır")]
        [MaxLength(100, ErrorMessage = "Ürün Adı En fazla 100 karakter olmalıdır")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Ürün Açıklaması boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Ürün Açıklaması En az 5 karakter olmalıdır")]
        [MaxLength(250, ErrorMessage = "Ürün Açıklaması En fazla 250 karakter olmalıdır")]
        public string Description { get; set; }
        public string Url { get; set; }

        [DisplayName("Ürün Fiyatı")]
        [Required(ErrorMessage = "Ürün Fiyatı boş bırakılmamalıdır")]
        public decimal? Price { get; set; }

        [DisplayName("Ana Sayfada Göster")]
        public bool IsHome { get; set; }

        [DisplayName("Onaylı Ürün")]
        public bool IsApproved { get; set; } = true;

        [DisplayName("Silinmiş Ürün")]
        public bool IsDeleted { get; set; }
        public DateTime UpdatedDate { get; set; }

        [DisplayName("Kategoriler")]
        public List<CategoryViewModel> Categories { get; set; }

        [Required(ErrorMessage = "En az bir kategori seçilmelidir")]
        public int[] SelectedCategories { get; set; }
        public string ImageUrl { get; set; }
        [DisplayName("Resim Yükle")]
        [Required(ErrorMessage = "Resim seçilmelidir")]
        public IFormFile ImageFile { get; set; }

    }
}
