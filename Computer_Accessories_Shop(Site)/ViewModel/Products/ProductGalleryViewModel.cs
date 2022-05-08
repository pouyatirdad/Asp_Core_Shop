using Microsoft.AspNetCore.Http;

namespace Computer_Accessories_Shop.Api.ViewModel.Products
{
    public class ProductGalleryViewModel
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public IFormFile File { get; set; }
        public string Title { get; set; }
        public int ProductID { get; set; }
    }
}
