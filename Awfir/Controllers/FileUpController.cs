using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using System.Web.Http.Cors;


namespace Awfir.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FileUpController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage UploadJsonFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            string datapath = string.Empty;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var filename = DateTime.Now.Ticks;
                    var postedFile = httpRequest.Files[file];
                    var name = Path.GetExtension(postedFile.FileName);
                    var fullfilename = filename + name;
                    var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/Image/"), fullfilename);
                    postedFile.SaveAs(filePath);
                    datapath = filePath;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, datapath);
        }

    }
}
