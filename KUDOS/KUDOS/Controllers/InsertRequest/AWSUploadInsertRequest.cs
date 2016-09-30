using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KUDOS.Controllers.InsertRequest
{
    public class AWSUploadInsertRequest
    {

        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }

        public string AwsBucket { get; set; }
    }
}