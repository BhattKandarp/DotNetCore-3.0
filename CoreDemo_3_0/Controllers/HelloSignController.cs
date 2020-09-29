using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoreDemo_3_0.Models;
using HelloSign;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo_3_0.Controllers
{
    public class HelloSignController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HelloSignController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Sign(string url)
        {
            ViewBag.Url = url;
            ViewBag.ClientId = HelloSignClientID;
            return View();
        }
        public ActionResult SendDocument()
        {

            SendDocumentViewModel model = new SendDocumentViewModel();
            return View(model);
        }
        public ActionResult CustomSign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendDocument(SendDocumentFormModel Form)
        {
            var fileName = "";
            var fullPath = "";

            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                var webRootPath = _hostingEnvironment.WebRootPath;
                var newPath = Path.Combine(webRootPath, "documents");
                if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);

                if (file.Length > 0)
                {
                    // MemoryStream memoryStream = inputStream as MemoryStream;
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {

                        file.CopyTo(stream);

                    }
                }
            }


            var client = new Client(HelloSignAPIKey);
            var request = new SignatureRequest();
            request.Subject = Form.Subject;
            request.Message = Form.Message;
            request.AddSigner(Form.SignerEmail, Form.SignerName);
            byte[] arreglo;// new byte[Form.File.ContentLength];
            arreglo = System.IO.File.ReadAllBytes(fullPath);

           // Form.File.InputStream.Read(arreglo, 0, Form.File.ContentLength);
            request.AddFile(arreglo, fileName);
            request.TestMode = true;
            var response = client.CreateEmbeddedSignatureRequest(request, HelloSignClientID);
            var urlSign = client.GetSignUrl(response.Signatures[0].SignatureId);
            return RedirectToAction("Sign", new { url = urlSign.SignUrl });
        }
    }
}