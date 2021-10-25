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
        public IActionResult View(int RoomId)
        {
            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == RoomId);
            if (roomChat == null) return Redirect("/Home/");

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if (LoginUser == null) return Redirect("/Home/");

            bool CheckRoomOfUser = roomChat.TeacherProfile.AccountID == LoginUser.Id
                                || roomChat.Class.StudentProfiles.Any(s => s.AccountID == LoginUser.Id);
                                
            if(!CheckRoomOfUser) return Redirect("/Home/");

            IEnumerable<RoomDeadLine> deadlines = RoomDeadLineDAOs.GetAllOfRoom(_context, RoomId);
            
            ViewData["RoomChat"] = roomChat;

            return View(deadlines);
        }

        // Mapping to view that create a new room deadline
        public IActionResult Create(int RoomId)
        {
            
            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == RoomId);
            if (roomChat == null) return Redirect("/Home/");

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if (LoginUser == null) return Redirect("/Home/");

            bool CheckRoomOfUser = roomChat.TeacherProfile.AccountID == LoginUser.Id
                                || roomChat.Class.StudentProfiles.Any(s => s.AccountID == LoginUser.Id);
                                
            if(!CheckRoomOfUser) return Redirect("/Home/");

            RoomDeadLine newRoomDeadLine = new RoomDeadLine(){
                RoomId = RoomId,
                RoomChat = roomChat
            };
            
            ViewData["ExpirationTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm").Replace(' ','T');
            return View(newRoomDeadLine);
        }

        // Receive data from create new deadline form and add data to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomDeadLine deadline){

            int RoomId = deadline.RoomId;

            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == RoomId);
            if (roomChat == null) return Redirect("/Home/");

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if (LoginUser == null) return Redirect("/Home/");

            bool CheckRoomOfUser = roomChat.TeacherProfile.AccountID == LoginUser.Id
                                || roomChat.Class.StudentProfiles.Any(s => s.AccountID == LoginUser.Id);
                                
            if(!CheckRoomOfUser) return Redirect("/Home/");

            

            if(deadline.Content != null && deadline.Content.Trim() != ""){

                deadline.Content = deadline.Content.Trim();
                _context.RoomDeadLines.Add(deadline);
                _context.SaveChanges();
                return Redirect($"/RoomDeadLine/View?RoomId={RoomId}");

            }
            ViewData["Error"] = "Content of deadline can not be blank...";
            ViewData["ExpirationTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm").Replace(' ','T');

            deadline.RoomChat = roomChat;
            return View(deadline);

        }
    }
}