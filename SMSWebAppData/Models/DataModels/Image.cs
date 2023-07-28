﻿using Microsoft.AspNetCore.Http;
using SMSWebAppData.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSWebAppData.Models.DataModels
{
    public class Image:BaseModel
    {
        public int ImageId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
