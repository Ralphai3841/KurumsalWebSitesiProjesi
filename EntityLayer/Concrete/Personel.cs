using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Personel
    {
        [Key]

        public int PersonelID { get; set; }
        public string FullName { get; set; }
        public string Telephone { get; set; }
        public string ImageUrl { get; set; }
    }
}
