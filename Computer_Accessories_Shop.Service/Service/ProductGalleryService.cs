

using Computer_Accessories_Shop.Data.Context;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Repository;

namespace Computer_Accessories_Shop.Service.Service
{
    public interface IProductGalleryService : IBaseRepository<ProductGallery>
    {
    }

    public class ProductGalleryService : BaseRepository<ProductGallery>, IProductGalleryService
    {
        private readonly MyDbContext context;
        public ProductGalleryService(MyDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
