using DotNetNuke.Web.Api;

namespace NM.Modules.NewsArticlesService.Controllers
{
    public class RouterMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("NM.NewsArticleService", "default", "{controller}/{action}",
                new string[] { "NM.Modules.NewsArticlesService.Controllers" });
        }
    }
}