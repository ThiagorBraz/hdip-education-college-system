using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDipEducationCollegeOfficial.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult WelcomePage()
        {
            return View();
        }
    }
}