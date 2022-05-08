

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Computer_Accessories_Shop.Data.Model
{
    public class ProductCategory
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(600, ErrorMessage = "{0} باید کمتر از 600 کارکتر باشد")]
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<Product> Products { get; set; }
        public int? ParentID { get; set; }
        public virtual ProductCategory Parent { get; set; }
        public virtual ICollection<ProductCategory> Children { get; set; }
    }
}
