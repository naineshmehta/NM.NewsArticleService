using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Api;
using NM.Modules.NM.NewsArticleService.Controllers;

namespace NM.Modules.NewsArticlesService.Controllers
{
    public class ExampleController : ControllerBase
    {
        [DnnAuthorize()]
        [HttpGet()]
        public HttpResponseMessage HelloWorld()
        {
            try
            {
                string helloWorld = "Hello World!";
                return Request.CreateResponse(HttpStatusCode.OK, helloWorld);
            }
            catch (System.Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}