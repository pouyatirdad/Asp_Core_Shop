using System.ComponentModel.DataAnnotations;

namespace Computer_Accessories_Shop.Api.ViewModel.Account
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required, Display(Name = "ایمیل"), EmailAddress]
        public string Email { get; set; }
        [Required, Display(Name = "رمز عبور"), DataType(DataType.Password), MaxLength(20), MinLength(6)]
        public string Password { get; set; }
        [Required, Display(Name = "تکرار رمز عبور"), Compare(nameof(Password)), DataType(DataType.Password)]
        public string RetypePassword { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
