using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop.Data.Model
{

    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public int Score { get; set; }

        public ICollection<Label> Labels { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
