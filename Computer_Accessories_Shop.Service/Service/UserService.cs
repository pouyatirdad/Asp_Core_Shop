

using Computer_Accessories_Shop.Data.Context;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;

namespace Computer_Accessories_Shop.Service.Service
{
    public interface IUserService : IBaseRepository<User>
    {
    }

    public class UserService : BaseRepository<User>, IUserService
    {
        private readonly MyDbContext context;
        public UserService(MyDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
