
using Computer_Accessories_Shop.Data.Context;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Repository;

namespace Computer_Accessories_Shop.Service.Service
{

    public interface IProductCommentService : IBaseRepository<ProductComment>
    {
    }

    public class ProductCommentService : BaseRepository<ProductComment>, IProductCommentService
    {
        private readonly MyDbContext context;
        public ProductCommentService(MyDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
