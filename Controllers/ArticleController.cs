using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.FileSystem;
using DotNetNuke.Web.Api;
using NM.Modules.NewsArticlesService.Models;
using NM.Modules.NM.NewsArticleService.Controllers;

namespace NM.Modules.NewsArticlesService.Controllers
{
    public class ImageController : ControllerBase
    {
        [DnnAuthorize()]
        [HttpGet()]
        public HttpResponseMessage GetFestivalImages()
        {
            try
            {
                //get the data from the File manager

                var logoFolder = FolderManager.Instance.GetFolder(PortalSettings.PortalId, "FestivalImages");
                var files = FolderManager.Instance.GetFiles(logoFolder);

                //map to an object that contains only the data we need
                var imageData = MapImagesDataImage(files).ToJson();

                return Request.CreateResponse(HttpStatusCode.OK, imageData);
            }
            catch (System.Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private static IEnumerable<Image> MapImagesDataImage(IEnumerable<IFileInfo> files)
        {

            return DotNetNuke.Common.Utilities.Json.Deserialize<IEnumerable<Image>>(files.ToJson());
        }
    }
}