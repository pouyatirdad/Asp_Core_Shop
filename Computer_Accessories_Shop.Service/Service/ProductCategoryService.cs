using Computer_Accessories_Shop.Data.Context;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Repository;

namespace Computer_Accessories_Shop.Service.Service
{
    public interface IProductCategoryService: IBaseRepository<ProductCategory>
    {
    }

    public class ProductCategoryService : BaseRepository<ProductCategory>, IProductCategoryService
    {
        private readonly MyDbContext context;
        public ProductCategoryService(MyDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
