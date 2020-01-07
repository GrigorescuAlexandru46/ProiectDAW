using Microsoft.AspNet.Identity;
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
            bool chatExists = false;
            Chat existingChat = null;

            var chats = from chat in db.Chats
                        select chat;

            List<Chat> chatsList = chats.ToList();

            foreach(Chat chat in chatsList)
            {
                if (((chat.Profile1.Id == ownProfileId) && (chat.Profile2.Id == targetProfileId)) || ((chat.Profile1.Id == targetProfileId) && (chat.Profile2.Id == ownProfileId)))
                {
                    chatExists = true;
                    existingChat = chat;
                }
            }
            if (chatExists)
                return RedirectToAction("Show", new { id = existingChat.Id });
            else
            {
                Chat newChat = new Chat();
                Profile ownProfile = db.Profiles.Find(ownProfileId);
                Profile targetProfile = db.Profiles.Find(targetProfileId);


                newChat.Profile1 = ownProfile;
                newChat.Profile2 = targetProfile;

                db.Chats.Add(newChat);
                db.SaveChanges();

                return RedirectToAction("Show", new { id = newChat.Id });
            }
        }

        public ActionResult Show(int id)
        {
            Chat chat = db.Chats.Find(id);
            Profile senderProfile = null;

            string ownUserId = User.Identity.GetUserId();
            var profiles = from profile in db.Profiles
                           where profile.UserId == ownUserId
                           select profile;

            senderProfile = profiles.ToList().First();

            ViewBag.Chat = chat;
            ViewBag.SenderProfile = senderProfile;
            return View();
        }
    }
}