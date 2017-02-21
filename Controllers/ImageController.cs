using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Api;
using NM.Modules.NewsArticlesService.Components;
using NM.Modules.NM.NewsArticleService.Controllers;

namespace NM.Modules.NewsArticlesService.Controllers
{
    public class ArticleController : ControllerBase
    {
        [DnnAuthorize()]
        [HttpGet()]
        public HttpResponseMessage GetArticleTypes()
        {
            try
            {
                //get the data from the DB
                var articleTypes = ArticleTypeManager.Instance.GetArticleTypes(PortalSettings.PortalId).ToJson();

                return Request.CreateResponse(HttpStatusCode.OK, articleTypes);
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