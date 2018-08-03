using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amanatak.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();

             
        }
         public ActionResult GotoControlPanal()
        {
            return RedirectToAction("Index", "main", new { area = "Operator" });
        }
            
    }
}