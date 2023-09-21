﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ImageCategory ImageCategory { get; set; }
        
        public int ImageCategoryID { get; set; }
    }
}
