using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop.Data.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Quality { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<Product> Products { get; set; }

        public string User_Name { get; set; }
        public User User { get; set; }
    }
}
