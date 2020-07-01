using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace lykaproduct.Models
{
    public class FileUploadModel
    {
        public string Title { get; set; }
        public string Descripction { get; set; }
        public string ImagePath { get; set; }
        [Display(Name ="Upload File")]
        public HttpPostedFileBase ImageFile { get; set; }


    }
}