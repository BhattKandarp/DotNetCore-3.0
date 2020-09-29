using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoreDemo_3_0.Entities;
using CoreDemo_3_0.Interface;
using CoreDemo_3_0.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;

namespace CoreDemo_3_0.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _jobManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public JobController(IJobService jobManager, IHostingEnvironment hostingEnvironment)
        {
            _jobManager = jobManager;
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index()
        {
            var data = _jobManager.ListAll();

            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            foreach (var item in data)
            {
                if (!string.IsNullOrEmpty(item.JobImage))
                    item.JobImage = Path.Combine(baseUrl, "Images", item.JobImage);
                else
                    item.JobImage = Path.Combine(baseUrl, "Images", "404.png");
            }
            return View(data);
        }

        #region Add Job  

        public ActionResult Add()
        {
            return View("Form", new JobModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(JobModel model)
        {
            if (ModelState.IsValid)
            {
                var fileName = "";
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    var newPath = Path.Combine(webRootPath, "images");
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
                }

                var job = new Job()
                {
                    CityId = model.CityId,
                    JobImage = fileName,
                    CreatedBY = "1",
                    CreatedDateTime = DateTime.Now,
                    JobTitle = model.JobTitle,
                    UpdatedBY = "1",
                    IsActive = model.IsActive,
                    UpdatedDateTime = DateTime.Now
                };

                _jobManager.Create(job);
                return RedirectToAction("Index", "Job");
            }
            return View("Form", model);
        }

        #endregion

        #region Edit Job  

        public ActionResult Edit(int JobId)
        {
            var jobEntity = _jobManager.GetByJobId(JobId);
            var jobModel = new JobModel
            {
                JobID = jobEntity.JobID,
                CityId = jobEntity.CityId,
                JobImage = jobEntity.JobImage,
                CreatedBY = jobEntity.CreatedBY,
                CreatedDateTime = jobEntity.CreatedDateTime,
                JobTitle = jobEntity.JobTitle,
                UpdatedBY = jobEntity.UpdatedBY,
                IsActive = jobEntity.IsActive,
                UpdatedDateTime = jobEntity.UpdatedDateTime
            };
            return View("Form", jobModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobModel model)
        {
            if (ModelState.IsValid)
            {
                var fileName = model.JobImage ?? "";
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    var newPath = Path.Combine(webRootPath, "images");
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
                }
                var job = new Job()
                {
                    JobID = model.JobID,
                    CityId = model.CityId,
                    JobImage = fileName,
                    JobTitle = model.JobTitle,
                    UpdatedBY = "1",
                    IsActive = model.IsActive,
                };

                _jobManager.Update(job);
                return RedirectToAction("Index", "Job");
            }
            return View("Form", model);
        }

        #endregion

        #region Delete Job  

        public ActionResult Delete(int JobId)
        {
            var jobEntity = _jobManager.Delete(JobId);
            return RedirectToAction("Index", "Job");
        }

        #endregion


        #region GENERATEREPORT DYNAMIC

        public FileResult GeneratePdfSharpCore()
        {
            //var doc = PdfSharpCore.(docPath);

            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            using (var doc = new PdfSharpCore.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Portrait;
                var graphics = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
                var coreFont = PdfSharpCore.Drawing.XBrushes.Black;

                var textFormate = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                var fontOrganise = new PdfSharpCore.Drawing.XFont("Arial", 10);
                var fontDescription = new PdfSharpCore.Drawing.XFont("Arial", 8, PdfSharpCore.Drawing.XFontStyle.BoldItalic);
                var titleDetails = new PdfSharpCore.Drawing.XFont("Arial", 14, PdfSharpCore.Drawing.XFontStyle.Bold);
                var fontDetailsDescription = new PdfSharpCore.Drawing.XFont("Arial", 7);

                var logo = @"D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\wwwroot\images\logo-type-2.png";
                var pageCount = doc.PageCount;
                textFormate.DrawString(pageCount.ToString(), new PdfSharpCore.Drawing.XFont("Arial", 10), coreFont, new PdfSharpCore.Drawing.XRect(578, 825, page.Width, page.Height));

                // Impressão do LogoTipo
                XImage image = XImage.FromFile(logo);
                graphics.DrawImage(image, 20, 5, 300, 50);

                //Pdf Title

                textFormate.DrawString("Name :", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(20, 75, page.Width, page.Height));
                textFormate.DrawString("Innopad Solutions LLP :", fontOrganise, coreFont, new PdfSharpCore.Drawing.XRect(80, 75, page.Width, page.Height));

                textFormate.DrawString("Email :", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(20, 95, page.Width, page.Height));
                textFormate.DrawString("info@innopadsolutions.com :", fontOrganise, coreFont, new PdfSharpCore.Drawing.XRect(80, 95, page.Width, page.Height));

                textFormate.DrawString("Mobile :", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(20, 115, page.Width, page.Height));
                textFormate.DrawString("+1973-931-6998 :", fontOrganise, coreFont, new PdfSharpCore.Drawing.XRect(80, 115, page.Width, page.Height));

                //Pdf Details

                var details = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                details.Alignment = PdfSharpCore.Drawing.Layout.XParagraphAlignment.Center;
                details.DrawString("Employee Details ", titleDetails, coreFont, new PdfSharpCore.Drawing.XRect(0, 120, page.Width, page.Height));

                //Pdf page details colum wise

                var detailsSizeOfY = 140;
                var columDetails = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                columDetails.DrawString("Name", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(20, detailsSizeOfY, page.Width, page.Height));

                columDetails.DrawString("Email", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(144, detailsSizeOfY, page.Width, page.Height));

                columDetails.DrawString("Phone", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(220, detailsSizeOfY, page.Width, page.Height));

                columDetails.DrawString("Address", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(290, detailsSizeOfY, page.Width, page.Height));

                columDetails.DrawString("Department", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(370, detailsSizeOfY, page.Width, page.Height));

                columDetails.DrawString("Sallery", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(450, detailsSizeOfY, page.Width, page.Height));
                columDetails.DrawString("Desination", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(490, detailsSizeOfY, page.Width, page.Height));


                //Pdf dyanmic data
                var detailsitemsize = 160;
                var data = _jobManager.ListOfEmployeeJob();
               foreach(var item in data)
                {
                    textFormate.DrawString(item.Name.ToString(), fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(21, detailsitemsize, page.Width, page.Height));

                    textFormate.DrawString(item.Email.ToString(), fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(145, detailsitemsize, page.Width, page.Height));
                    textFormate.DrawString(item.Phone, fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(215, detailsitemsize, page.Width, page.Height));
                    textFormate.DrawString(item.Address, fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(290, detailsitemsize, page.Width, page.Height));
                    textFormate.DrawString(item.Department, fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(370, detailsitemsize, page.Width, page.Height));
                    textFormate.DrawString("xxx000", fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(450, detailsitemsize, page.Width, page.Height));
                    textFormate.DrawString(item.Desination, fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(490, detailsitemsize, page.Width, page.Height));

                    detailsitemsize += 20;
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    var contantType = "application/pdf";
                    doc.Save(stream, false);
                    var nameOfFile = "Employee.pdf";
                    return File(stream.ToArray(), contantType, nameOfFile);
                }
            }

        }



        #endregion



        #region PDF GENERATE BY STATIC DATA

        //public FileResult GeneratePdfSharpCore()
        //{
        //    using (var doc = new PdfSharpCore.Pdf.PdfDocument())
        //    {
        //        var page = doc.AddPage();
        //        page.Size = PdfSharpCore.PageSize.A4;
        //        page.Orientation = PdfSharpCore.PageOrientation.Portrait;
        //        var graphics = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
        //        var coreFont = PdfSharpCore.Drawing.XBrushes.Black;

        //        var textFormate = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
        //        var fontOrganise = new PdfSharpCore.Drawing.XFont("Arial", 10);
        //        var fontDescription = new PdfSharpCore.Drawing.XFont("Arial", 8, PdfSharpCore.Drawing.XFontStyle.BoldItalic);
        //        var titleDetails = new PdfSharpCore.Drawing.XFont("Arial", 14, PdfSharpCore.Drawing.XFontStyle.Bold);
        //        var fontDetailsDescription = new PdfSharpCore.Drawing.XFont("Arial", 7);

        //        var logo = @"D:\AspNetCore\PdfSharpCore\WebPdfSharpCore\WebPdfSharpCore\wwwroot\images\logo1.png";
        //        var pageCount = doc.PageCount;
        //        textFormate.DrawString(pageCount.ToString(), new PdfSharpCore.Drawing.XFont("Arial", 10), coreFont, new PdfSharpCore.Drawing.XRect(578, 825, page.Width, page.Height));

        //        // Impressão do LogoTipo
        //        XImage image = XImage.FromFile(logo);
        //        graphics.DrawImage(image, 20, 5, 300, 50);

        //        //Pdf Title

        //        textFormate.DrawString("Name :", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(20, 75, page.Width, page.Height));
        //        textFormate.DrawString("Jitendra Joshi :", fontOrganise, coreFont, new PdfSharpCore.Drawing.XRect(80, 75, page.Width, page.Height));

        //        textFormate.DrawString("Email :", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(20, 95, page.Width, page.Height));
        //        textFormate.DrawString("joshijitu66@gmail.com :", fontOrganise, coreFont, new PdfSharpCore.Drawing.XRect(80, 95, page.Width, page.Height));

        //        textFormate.DrawString("Mobile :", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(20, 115, page.Width, page.Height));
        //        textFormate.DrawString("+9587736762 :", fontOrganise, coreFont, new PdfSharpCore.Drawing.XRect(80, 115, page.Width, page.Height));

        //        //Pdf Details

        //        var details = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
        //        details.Alignment = PdfSharpCore.Drawing.Layout.XParagraphAlignment.Center;
        //        details.DrawString("Details ", titleDetails, coreFont, new PdfSharpCore.Drawing.XRect(0, 120, page.Width, page.Height));

        //        //Pdf page details colum wise

        //        var detailsSizeOfY = 140;
        //        var columDetails = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
        //        columDetails.DrawString("Title", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(20, detailsSizeOfY, page.Width, page.Height));

        //        columDetails.DrawString("Address", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(144, detailsSizeOfY, page.Width, page.Height));

        //        columDetails.DrawString("Country", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(220, detailsSizeOfY, page.Width, page.Height));

        //        columDetails.DrawString("Description", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(290, detailsSizeOfY, page.Width, page.Height));

        //        columDetails.DrawString("Status", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(370, detailsSizeOfY, page.Width, page.Height));

        //        columDetails.DrawString("Date", fontDescription, coreFont, new PdfSharpCore.Drawing.XRect(450, detailsSizeOfY, page.Width, page.Height));

        //        //Pdf dyanmic data
        //        var detailsitemsize = 160;
        //        for (var i = 1; i < 300; i++)
        //        {
        //            textFormate.DrawString("Title" + " : " + i.ToString(), fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(21, detailsitemsize, page.Width, page.Height));
        //            textFormate.DrawString("Address" + " : " + i.ToString(), fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(145, detailsitemsize, page.Width, page.Height));
        //            textFormate.DrawString("Country" + " : " + i.ToString(), fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(215, detailsitemsize, page.Width, page.Height));
        //            textFormate.DrawString("Description" + " : " + i.ToString(), fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(290, detailsitemsize, page.Width, page.Height));
        //            textFormate.DrawString("Status" + " : " + i.ToString(), fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(370, detailsitemsize, page.Width, page.Height));
        //            textFormate.DrawString(DateTime.Now.ToString(), fontDetailsDescription, coreFont, new PdfSharpCore.Drawing.XRect(450, detailsitemsize, page.Width, page.Height));
        //            detailsitemsize += 20;
        //        }

        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            var contantType = "application/pdf";
        //            doc.Save(stream, false);
        //            var nameOfFile = "BasicDetails.pdf";
        //            return File(stream.ToArray(), contantType, nameOfFile);
        //        }
        //    }

        //}

        #endregion

    }
}