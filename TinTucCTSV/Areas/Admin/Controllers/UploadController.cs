using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _hostingEnviroment;
        public UploadController(IHostingEnvironment hostingEnviroment){
            _hostingEnviroment = hostingEnviroment;
        }

        [HttpPost]
        public IActionResult PathUpload(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(),_hostingEnviroment.WebRootPath,"uploaded",fileName);
            var streamF = new FileStream(path,FileMode.Create);
            file.CopyToAsync(streamF);

            return new JsonResult(new {path = "updated/images" + "/" + fileName});
        }
    }
}