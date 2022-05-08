

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Computer_Accessories_Shop.Data.Model
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(600, ErrorMessage = "{0} باید کمتر از 600 کارکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیح کوتاه")]
        [DataType(DataType.MultilineText)]
        [MaxLength(2000, ErrorMessage = "{0} باید کمتر از 2000 کارکتر باشد")]
        public string ShortDescription { get; set; }
        [Display(Name = "توضیح")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long Price { get; set; }
        [Display(Name = "تخفیف")]
        public int Discount { get; set; }
        [Display(Name = "تصویر محصول")]
        public string Image { get; set; }

        [Display(Name = "امتیاز محصول")]
        public int Rate { get; set; }
        public int? ProductCategoryID { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ICollection<ProductGallery> ProductGalleries { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
    }
}
