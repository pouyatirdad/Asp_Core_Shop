

using Computer_Accessories_Shop.Data.Context;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Repository;

namespace Computer_Accessories_Shop.Service.Service
{
    public interface IOrderService : IBaseRepository<Order>
    {
    }

    public class OrderService : BaseRepository<Order>, IOrderService
    {
        private readonly MyDbContext context;
        public OrderService(MyDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
