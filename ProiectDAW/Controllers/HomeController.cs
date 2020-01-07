using Microsoft.AspNet.Identity;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            if (TempData.ContainsKey("Error"))
            {
                ViewBag.message = TempData["Error"].ToString();
            }

            string ownUserId = User.Identity.GetUserId();
            var profiles = from profile in db.Profiles
                           where profile.UserId == ownUserId
                           select profile;

            List<Profile> profilesList = profiles.ToList();

            ViewBag.UserHasProfile = false;
            foreach (Profile profile in profilesList)
            {
                if (profile.UserId == User.Identity.GetUserId())
                {
                    ViewBag.UserHasProfile = true;
                    ViewBag.Profile = profile;
                }
            }

            return View();
        }
    }
}