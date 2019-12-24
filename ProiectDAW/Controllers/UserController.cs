using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProiectDAW.Models;


namespace ProiectDAW.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var users = from user in db.Users
                        select user;
            ViewBag.Users = users;
            return View();
        }

        public ActionResult Show(int id)
        {
            User user = db.Users.Find(id);
            ViewBag.User = user;
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);
            ViewBag.User = user;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, User requestStudent)
        {
            try
            {
                User user = db.Users.Find(id);
                if (TryUpdateModel(user))
                {
                    user.name = requestStudent.name;
                    user.age = requestStudent.age;
                    user.description = requestStudent.description;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}