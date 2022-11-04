using Computer_Accessories_Shop.Data.Context;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Service;
using Computer_Accessories_Shop.Api.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop_Site_.ViewComponents
{

    public class UsersWithScoreViewComponent : ViewComponent
    {
        private readonly IUserService userService;

        public UsersWithScoreViewComponent(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = userService.GetAll();

            var model = new List<UserWIthScore>();

            foreach (var user in users)
            {
                model.Add(new UserWIthScore
                {
                    UserName = user.UserName,
                    Score = user.Score
                }
                );
            }

            return View(model);
        }
    }
}
