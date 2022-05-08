using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Computer_Accessories_Shop.Api.ViewModel.Products
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public IFormFile File { get; set; }
        public string Image { get; set; }
        public int? ParentID { get; set; }
    }
}
