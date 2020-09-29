using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo_3_0.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo_3_0.Controllers
{
    public class JobSchedulingController : Controller
    {
        private readonly IJobSchedulingService _jobSchedulingService;

        public JobSchedulingController(IJobSchedulingService jobSchedulingService)
        {
            _jobSchedulingService = jobSchedulingService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetJobScheduling()
        {
            var data = _jobSchedulingService.GetAllSchedulingList();
            return Json(data);
        }
        public IActionResult Calendar()
        {
            return View();
        }
        
    }
}