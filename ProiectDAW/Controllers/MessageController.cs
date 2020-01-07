using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class MessageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Message message, int senderProfileId, int chatId)
        {
            Chat chat = db.Chats.Find(chatId);
            Profile senderProfile = db.Profiles.Find(senderProfileId);

            message.SenderProfile = senderProfile;
            chat.Messages.Add(message);

            db.Messages.Add(message);
            db.SaveChanges();

            return RedirectToAction("Show", "Chat", new { id = chatId });
        }
    }
}