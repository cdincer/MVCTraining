using MVCTraining.Extensions;
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
        public async Task<ActionResult> Register(string code)
        {

            if (Request.IsAuthenticated)
            {
                var userId = HttpContext.GetUserId();

                var registered = await SubscriptionExtensions.RegisterUserSubscriptionCode(userId,code);
                if (!registered)
                {
                    throw new ApplicationException();
                }

                return PartialView("_RegisterCodePartial");

            }
            return View();
        }




    }
}