using Amanatak.Models;
using AmanatakBLL;
using AmanatakBLL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amanatak.Areas.Operator.Controllers
{
    public class MainController : Controller
    {
        private AmanatakContext db = new AmanatakContext();

        // GET: Operator/Home
        public ActionResult Index()
        {
            return View();
        }
    

    }
}