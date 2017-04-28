using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Controllers
{
    public class AllFeedbacksController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}