

using Computer_Accessories_Shop.Data.Context;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Computer_Accessories_Shop.Service.Service
{

    public interface IProductService : IBaseRepository<Product>
    {
        public IEnumerable<Product> GetProductsHasDiscount(int num);
        public IEnumerable<Product> GetProductsByAddedDate(int num);
    }

    public class ProductService : BaseRepository<Product>, IProductService
    {
        private readonly MyDbContext context;
        public ProductService(MyDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProductsByAddedDate(int num)
        {
            return GetAll().OrderByDescending(x=>x.AddedDate).Take(num);
        }

        public IEnumerable<Product> GetProductsHasDiscount(int num)
        {
            return GetAll().Where(x => x.Discount > 0).Take(num);
        }
    }
}
