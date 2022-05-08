using Microsoft.AspNetCore.Http;

namespace Computer_Accessories_Shop.Api.ViewModel.Products
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public int Discount { get; set; }
        public IFormFile File { get; set; }
        public string Image { get; set; }
        public int Rate { get; set; }
        public int? ProductCategoryID { get; set; }
    }
}