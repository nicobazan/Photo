using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KUDOS.Controllers.Domain
{
    public class FileUpload
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string AwsBucket { get; set; }
        public int id { get; set; }
    }
}