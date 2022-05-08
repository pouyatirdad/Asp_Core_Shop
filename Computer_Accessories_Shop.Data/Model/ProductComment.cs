

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Computer_Accessories_Shop.Data.Model
{
    public class ProductComment
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} باید کمتر از 300 کارکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل نا معتبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} باید کمتر از 400 کارکتر باشد")]
        public string Email { get; set; }
        [Display(Name = "پیام")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "{0} باید کمتر از 800 کارکتر باشد")]
        public string Message { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime? AddedDate { get; set; }
        [Display(Name = "امتیاز")]
        public int? Rate { get; set; }
        public int? ParentId { get; set; }
        public virtual ProductComment Parent { get; set; }
        public virtual ICollection<ProductComment> Children { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
