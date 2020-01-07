using Microsoft.AspNet.Identity;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "User,Administrator")]
        public ActionResult Index()
        {

            return View();
        }

        [NonAction]
        public Profile GetOwnProfile()
        {
            string ownUserId = User.Identity.GetUserId();

            var profiles = from profile in db.Profiles
                           where profile.UserId == ownUserId
                           select profile;

            return profiles.ToList().First();
        }

        [NonAction]
        public bool UserHasProfile()
        {
            string ownUserId = User.Identity.GetUserId();
            var profiles = from profile in db.Profiles
                           where profile.UserId == ownUserId
                           select profile;

            List<Profile> profilesList = profiles.ToList();

            foreach(Profile profile in profilesList)
            {
                if (profile.UserId == User.Identity.GetUserId())
                    return true;
            }

            return false;
        }

        [Authorize(Roles = "User,Administrator")]
        public ActionResult Show(int id)
        {
            try
            {
                Profile profile = db.Profiles.Find(id);
                ViewBag.Profile = profile;

                if (profile.UserId == User.Identity.GetUserId() || User.IsInRole("Administrator"))
                    ViewBag.CanEdit = true;
                else
                    ViewBag.CanEdit = false;

                if (!profile.IsPrivate)
                    ViewBag.CanShow = true;
                else
                    if ((profile.UserId == User.Identity.GetUserId()) || User.IsInRole("Administrator"))
                    ViewBag.CanShow = true;
                else
                    ViewBag.CanShow = false;

                if (profile.UserId == User.Identity.GetUserId())
                    ViewBag.IsOwner = true;
                else
                    ViewBag.IsOwner = false;

                ViewBag.OwnProfile = GetOwnProfile();

                return View();
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        [Authorize(Roles = "User,Administrator")]
        public ActionResult New()
        {
            if (UserHasProfile())
            {
                TempData["Error"] = "You already have a profile";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User,Administrator")]
        public ActionResult New(Profile profile)
        {
            try
            {
                profile.UserId = User.Identity.GetUserId();

                db.Profiles.Add(profile);
                db.SaveChanges();

                return RedirectToAction("Show", new { id = profile.Id });
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [Authorize(Roles = "User,Administrator")]
        public ActionResult Edit(int id)
        {
            try
            {
                Profile profile = db.Profiles.Find(id);
                ViewBag.Profile = profile;
                return View();
            }
            catch
            {
                return Content("Exception");
            }
        }

        [HttpPut]
        [Authorize(Roles = "User,Administrator")]
        public ActionResult Edit(int id, Profile requestProfile)
        {
            try
            {
                Profile profile = db.Profiles.Find(id);
                if (TryUpdateModel(profile))
                {
                    profile.FirstName = requestProfile.FirstName;
                    profile.LastName = requestProfile.LastName;
                    profile.Age = requestProfile.Age;
                    profile.Description = requestProfile.Description;
                    db.SaveChanges();
                }
                return RedirectToAction("Show", new { id = profile.Id });
            }
            catch (Exception e)
            {
                return Content("Exception");
            }
        }

        [HttpDelete]
        [Authorize(Roles = "User,Administrator")]
        public ActionResult Delete(int id)
        {
            Profile profile = db.Profiles.Find(id);

            db.Profiles.Remove(profile);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "User,Administrator")]
        public ActionResult Search()
        {
            return View();
        }

        [Authorize(Roles = "User,Administrator")]
        public ActionResult Results(String searchFirstName, String searchLastName)
        {

            var profiles = from profile in db.Profiles
                           where profile.FirstName == searchFirstName || profile.LastName == searchLastName
                           select profile;

            if (profiles.Count() == 0)
                ViewBag.Profiles = null;
            else
                ViewBag.Profiles = profiles.ToList();
            ViewBag.searchFirstName = searchFirstName;
            ViewBag.searchLastName = searchLastName;

            return View();
        }
    }
}