﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace LPEntities
{
    public class Media
    {
        public int ImageID { get; set; }
        public string Title { get; set; }
        public string Descripction { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        [Display(Name = "Upload File")]
        public HttpPostedFileBase ImageFile { get; set; }


    }
}
