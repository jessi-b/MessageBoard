using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MessageBoard.Models;

namespace MessageBoard.Controllers {
  public class MessagesController : Controller {
    private readonly MessageBoardContext _db;
    public MessagesController(MessageBoardContext db) {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Messages.ToList());
    }

    [HttpPost]
    public ActionResult Create(Message message, int RoomId) 
    {
      _db.Messages.Add(message);
      _db.SaveChanges();
      _db.RoomMessages.Add(new RoomMessage() { RoomId = RoomId, MessageId = message.MessageId });
      _db.SaveChanges();
      return RedirectToAction($"Details/{RoomId}", "Rooms");
    }
    
    public ActionResult Details(int id)
    {
    var thisMessage = _db.Messages
      .Include(message => message.JoinEntities)
      .ThenInclude(join => join.Room)
      .FirstOrDefault(message => message.MessageId == id);
    ViewBag.ListOfUsers = _db.Users.ToList();
    ViewBag.UserDeets = _db.Users.FirstOrDefault(u => u.UserId == thisMessage.UserId);
    ViewBag.User = thisMessage.User;
    return View(thisMessage);
    }
  }
}
