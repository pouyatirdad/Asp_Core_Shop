using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Computer_Accessories_Shop.Api.ViewModel.Account
{
    public class UserWIthScore
    {
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Display(Name = "امتیاز")]
        public int Score { get; set; }
    }
}
