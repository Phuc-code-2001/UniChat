using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniChatApplication.Models;
using UniChatApplication.Daos;
using UniChatApplication.Data;

namespace UniChatApplication.Controllers
{
    public class RoomDeadLineController : Controller
    {

        readonly UniChatDbContext _context;

        public RoomDeadLineController(UniChatDbContext context)
        {
            _context = context;
        }

        // View All RoomDeadLine of a room
        public IActionResult ViewAll(int? RoomId)
        {
            if (RoomId == null) return Redirect("/Home/");
            IEnumerable<RoomDeadLine> deadlines = RoomDeadLineDAOs.GetAllOfRoom(_context, (int) RoomId);
            
            ViewData["RoomId"] = RoomId;

            return View(deadlines);
        }

        // Mapping to view that create a new room deadline
        public IActionResult Create(int? RoomId)
        {
            
            if (RoomId == null) return Redirect("/Home/");
            
            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == RoomId);
            if (roomChat == null) return Redirect("/Home/");

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if (LoginUser == null) return Redirect("/Home/");

            bool CheckRoomOfUser = roomChat.TeacherProfile.AccountID == LoginUser.Id
                                || roomChat.Class.StudentProfiles.Any(s => s.AccountID == LoginUser.Id);
                                
            if(!CheckRoomOfUser) return Redirect("/Home/");

            RoomDeadLine newRoomDeadLine = new RoomDeadLine(){
                RoomId = (int) RoomId,
                ExpirationTime = DateTime.Now
            };

            return View(newRoomDeadLine);
        }

        // Receive data from create new deadline form and add data to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomDeadLine deadline){

            if(ModelState.IsValid){

                _context.RoomDeadLines.Add(deadline);
                _context.SaveChanges();
                return RedirectToAction("RoomChat", "Box", deadline.RoomId);

            }

            return View(deadline);

        }
    }
}