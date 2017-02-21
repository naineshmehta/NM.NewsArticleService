using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using NM.Modules.NewsArticlesService.Models;

namespace NM.Modules.NewsArticlesService.Components
{
    interface IArticleTypeManager
    {
        IEnumerable<ArticleType> GetArticleTypes(int portalId);
    }

    class ArticleTypeManager : ServiceLocator<IArticleTypeManager, ArticleTypeManager>, IArticleTypeManager
    {
        protected override Func<IArticleTypeManager> GetFactory()
        {
            return () => new ArticleTypeManager();
        }

        public IEnumerable<ArticleType> GetArticleTypes(int portalId)
        {
            IEnumerable<ArticleType> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                t = ctx.ExecuteQuery<ArticleType>(CommandType.StoredProcedure, "NM_NewsArticles_GetArticleTypes", portalId);
            }
            return t;
        }
    }
}