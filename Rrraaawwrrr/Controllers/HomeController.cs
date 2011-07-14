using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rrraaawwrrr.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to the Friggin MVC Dungeon!";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PlainText()
        {
            return new ContentResult() { Content = "Ggrrr", ContentType="text/plain" };
        }
    }
}
