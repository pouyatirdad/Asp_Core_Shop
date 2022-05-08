using System.ComponentModel.DataAnnotations;

namespace Computer_Accessories_Shop.Api.ViewModel.Account
{
    public class LoginViewModel
    {
        [Required, Display(Name = "ایمیل"), EmailAddress]
        public string Email { get; set; }
        [Required, Display(Name = "رمز عبور"), DataType(DataType.Password), MaxLength(20), MinLength(6)]
        public string Password { get; set; }
    }
}
