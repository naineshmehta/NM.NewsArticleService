using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NM.Modules.NewsArticlesService.Models
{
    public class Image
    {
        public int FileId { get; set; }
        public string Folder { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string ContentType { get; set; }
    }
}