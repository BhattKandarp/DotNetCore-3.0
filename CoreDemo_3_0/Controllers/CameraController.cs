using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoreDemo_3_0.Entities;
using CoreDemo_3_0.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo_3_0.Controllers
{
    public class CameraController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly IImageStoreService _imageStoreService;

        public CameraController(IHostingEnvironment hostingEnvironment, IImageStoreService imageStoreService)
        {
            _environment = hostingEnvironment;
            _imageStoreService = imageStoreService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Capture()
        {
           
            return View();
        }


        [HttpGet]
        public IActionResult Capture1()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Capture(string name)
        {
            var fileName = "";
            try
            {
               
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    var webRootPath = _environment.WebRootPath;
                    var newPath = Path.Combine(webRootPath, "CameraPhotos");
                    if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);

                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(newPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                    ImageStore _objImageStore = new ImageStore();
                    _objImageStore.ImageUrl = fileName;
                    _imageStoreService.StoreWebCamImage(_objImageStore);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(fileName);

        }
    }
}