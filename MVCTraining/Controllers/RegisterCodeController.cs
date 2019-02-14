using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCTraining.Controllers
{
    public class RegisterCodeController : Controller
    {
        // GET: RegisterCode
        public async Task<ActionResult> Register()
        {

            return View();
        }
    }
}