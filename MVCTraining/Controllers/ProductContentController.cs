using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTraining.Controllers
{
    public class ProductContentController : Controller
    {
        // GET: ProductContent
        public ActionResult Index()
        {
            return View();
        }
    }
}