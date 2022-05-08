

using System.ComponentModel.DataAnnotations;

namespace Computer_Accessories_Shop.Data.Model
{
    public class ProductGallery
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        [Display(Name = "عنوان تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
