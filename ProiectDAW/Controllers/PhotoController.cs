using Microsoft.AspNet.Identity;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class PhotoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "User,Administrator")]
        public ActionResult New(int profileId)
        {
            ViewBag.ProfileId = profileId;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User,Administrator")]
        public ActionResult New(Photo photo, int profileId)
        {
            try
            {
                Profile profile = db.Profiles.Find(profileId);

                profile.Photos.Add(photo);
                photo.Profile = profile;

                db.Photos.Add(photo);
                db.SaveChanges();

                return RedirectToAction("Show", "Profile", new { id = profile.Id });
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpDelete]
        [Authorize(Roles = "User,Administrator")]
        public ActionResult Delete(int id)
        {
            Photo photo = db.Photos.Find(id);
            Profile profile = photo.Profile;

            profile.Photos.Remove(photo);
            db.Photos.Remove(photo);
            db.SaveChanges();

            return RedirectToAction("Show", "Profile", new { id = profile.Id });
        }
    }
}