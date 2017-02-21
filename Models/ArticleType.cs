using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NM.Modules.NewsArticlesService.Models
{
    public class ArticleType
    {
        public int TabModuleId { get; set; }
        public int TabId { get; set; }
        public int ModuleId { get; set; }
        public string ModuleTitle { get; set; }
    }
}