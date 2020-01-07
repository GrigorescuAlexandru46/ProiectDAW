using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class ChatController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Check(int ownProfileId, int targetProfileId)
        {
            return Content(ownProfileId.ToString() + " ---> " + targetProfileId.ToString());

            return View();
        }
    }
}