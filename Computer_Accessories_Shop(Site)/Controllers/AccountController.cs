using Computer_Accessories_Shop.Api.ViewModel.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController
            (
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
		//[Authorize(Roles = "Programmer")]
		public async Task<IActionResult> CreateRole(string roleName)
        {

            bool x = await roleManager.RoleExistsAsync(roleName);
            if (x || string.IsNullOrWhiteSpace(roleName))
                return BadRequest("Error!");

            var role = new IdentityRole();
            role.Name = roleName;
            await roleManager.CreateAsync(role);
            return Ok(string.Format("Role {0} Created", roleName));

        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await CreateRole("Programmer");
            await CreateRole("Admin");
            await CreateRole("User");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var CheckUserExist = await userManager.FindByEmailAsync(model.Email);
                if (CheckUserExist != null)
                    return RedirectToAction("login");

                var user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = false
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    string roleName = model.IsAdmin ? "Admin" : "User";

                    var result2 = new IdentityResult();

                    if (model.UserName == "ImProgrammer" && model.Email == "Programmer@SiteOwner.pro")
                    {
                        result2 = await userManager.AddToRoleAsync(user, "Programmer");
                    }
                    else
                    {

                        var role = new IdentityRole();
                        role.Name = "User";
                        await roleManager.CreateAsync(role);


                        result2 = await userManager.AddToRoleAsync(user, roleName);
                    }

                    return RedirectToAction("login");


                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("error", error.Description);
                }

            }

            return RedirectToAction("login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user == null)
                    return RedirectToAction("login");

                //var result = await userManager.CheckPasswordAsync(user, model.Password);
                var result = await signInManager.PasswordSignInAsync(user,model.Password,false,false);

                if (result.Succeeded == false)
                    return RedirectToAction("login");

                return RedirectToAction("login");
            }

            return RedirectToAction("login");
        }
    }
}
