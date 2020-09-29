using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo_3_0.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo_3_0.Controllers
{
    public class JobVacancyController : Controller
    {
        public readonly IVacancyService _vacancyService;


        public JobVacancyController(IVacancyService vacancyservice)
        {
            _vacancyService = vacancyservice;
        }

        public IActionResult Index()
        {
            var data = _vacancyService.GetVacancyList();
            return View(data);
        }
    }
}