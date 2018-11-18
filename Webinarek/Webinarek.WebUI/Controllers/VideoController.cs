using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Webinarek.Models;

namespace Webinarek.Controllers
{
    [RoutePrefix(@"api")]
    public class VideoController : ApiController
    {
        [Route(@"video/{fileName}/{mimeType}"), HttpGet]
        public HttpResponseMessage Video(string fileName, string mimeType)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var path = Path.Combine(root, $@"{fileName}.{mimeType}");
            var videoStream = new VideoStream(path);
            response.Content = new PushStreamContent(videoStream.WriteToStream, new MediaTypeHeaderValue($@"video/{mimeType}"));
            return response;
        }
    }
}
