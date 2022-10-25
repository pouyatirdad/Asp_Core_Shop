using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop.Data.Model
{
    public class Label
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NeededScore { get; set; }

        public string User_Name { get; set; }
        public User User { get; set; }
    }
}
