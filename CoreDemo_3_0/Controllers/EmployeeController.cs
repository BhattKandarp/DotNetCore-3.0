using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoreDemo_3_0.Interface;
using CoreDemo_3_0.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo_3_0.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EmployeeController(IEmployeeService employeeServices, IHostingEnvironment hostingEnvironment)
        {
            _employeeService = employeeServices;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var data = _employeeService.GetAllEmployeeList();

            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            foreach (var item in data)
            {
                if (!string.IsNullOrEmpty(item.Image))
                    item.Image = Path.Combine(baseUrl, "employee", item.Image);
                else
                    item.Image = Path.Combine(baseUrl, "employee", "404.png");
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Employee(int employeeid = 0)
        {
            if (employeeid > 0)
            {
                var data = _employeeService.GetEmployeeById(employeeid);
                var employee = new EmployeeModel()
                {
                    Id = data.Id,
                    Firstname = data.Firstname,
                    Lastname = data.Lastname,
                    Email = data.Email,
                    Mobile = data.Mobile,
                    DOB = data.DOB,
                    Image=data.Image
                };
                return View(employee);
            }
            else
                return View(new EmployeeModel());

        }

        [HttpPost]
        public IActionResult Employee(EmployeeModel _employeeModel)
        {
            if (ModelState.IsValid)
            {
                var fileName = "";
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    var newPath = Path.Combine(webRootPath, "employee");
                    if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);

                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(newPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        _employeeModel.Image = fileName;
                    }
                }
            }

            _employeeService.AddUpdateEmployee(_employeeModel);
            return RedirectToAction("Index", "Employee");
        }

        public IActionResult DeleteEmployee(int EmployeeId)
        {
            _employeeService.DeleteEmployee(EmployeeId);
            return RedirectToAction("Index", "Employee");
        }

    }
}