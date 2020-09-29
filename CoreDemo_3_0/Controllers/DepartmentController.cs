using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo_3_0.Interface;
using CoreDemo_3_0.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo_3_0.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _department;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DepartmentController(IDepartmentService department, IHostingEnvironment hostingEnvironment)
        {
            _department = department;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View(_department.GetDepartmentList());
        }
        [HttpGet]
        public ActionResult ManageDepartment(int DepartmentId = 0)
        {
            if (DepartmentId > 0)
            {
                var data = _department.GetDepartmentById(DepartmentId);
                var departmentModel = new DepartmentModel()
                {
                    Id = data.Id,
                    DepartmentTitle = data.Department
                };
                return View(departmentModel);
            }
            else
            {
                return View(new DepartmentModel());
            }

        }

        [HttpPost]
        public ActionResult ManageDepartment(DepartmentModel departmentModel)
        {
            _department.ManageDepartment(departmentModel);
            return RedirectToAction("Index", "Department");
        }

        public ActionResult DeleteDepartment(int DepartmentId)
        {
            var data = _department.DeleteDepartment(DepartmentId);
            return RedirectToAction("Index", "Department");
        }
    }
}