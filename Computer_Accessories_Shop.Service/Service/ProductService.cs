

using Computer_Accessories_Shop.Data.Context;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Repository;

namespace Computer_Accessories_Shop.Service.Service
{

    public interface IProductService : IBaseRepository<Product>
    {
    }

    public class ProductService : BaseRepository<Product>, IProductService
    {
        private readonly MyDbContext context;
        public ProductService(MyDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
