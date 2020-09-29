using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo_3_0.Controllers
{
    public class BaseController : Controller
    {
        protected string HelloSignAPIKey = "b1a98ec6e3ccd8f916b15993f842b48f21cb796ffb08f6732c4f7748293d106a";// ConfigurationManager.AppSettings["HelloSignAPIKey"];
        protected string HelloSignClientID = "d029c750f44777d3ade525029dd933ed";// ConfigurationManager.AppSettings["HelloSignClientID"];
        public ActionResult Index()
        {
            return View();
        }
    }
}