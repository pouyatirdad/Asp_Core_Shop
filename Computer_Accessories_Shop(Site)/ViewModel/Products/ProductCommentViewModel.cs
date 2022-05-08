using System;

namespace Computer_Accessories_Shop.Api.ViewModel.Products
{
    public class ProductCommentViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? Rate { get; set; }
        public int? ParentId { get; set; }
        public int ProductID { get; set; }

    }
}