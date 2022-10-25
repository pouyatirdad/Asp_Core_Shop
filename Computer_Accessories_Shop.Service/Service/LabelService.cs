

using Computer_Accessories_Shop.Data.Context;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Repository;

namespace Computer_Accessories_Shop.Service.Service
{
    public interface ILabelService : IBaseRepository<Label>
    {
    }

    public class LabelService : BaseRepository<Label>, ILabelService
    {
        private readonly MyDbContext context;
        public LabelService(MyDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
