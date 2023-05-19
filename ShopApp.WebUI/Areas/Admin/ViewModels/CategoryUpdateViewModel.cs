using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Areas.Admin.ViewModels
{
    public class CategoryUpdateViewModel
    {
        public int Id { get; set; }

        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "Kategori adı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Kategori adı en az 5 karakter olmalıdır")]
        [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olmalıdır")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "Kategori açıklaması boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Kategori açıklaması en az 5 karakter olmalıdır")]
        [MaxLength(500, ErrorMessage = "Kategori açıklaması en fazla 500 karakter olmalıdır")]
        public string Description { get; set; }
        public string Url { get; set; }

        [DisplayName("Onaylı mı?")]
        public bool IsApproved { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
