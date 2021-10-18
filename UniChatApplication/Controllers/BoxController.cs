using Microsoft.AspNetCore.Mvc;
using UniChatApplication.Data;
using UniChatApplication.Daos;
using UniChatApplication.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace UniChatApplication.Controllers
{
    
    public class BoxController : Controller {
        

        readonly UniChatDbContext _context;

        public BoxController(UniChatDbContext context){
            _context = context;
        }

        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("Role") != "Student"
            && HttpContext.Session.GetString("Role") != "Teacher") return Redirect("/Home/");

            List<RoomChat> roomChats;

            Account loginAccount = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if(loginAccount.RoleName == "Teacher"){

                TeacherProfile profile = (TeacherProfile) ProfileDAOs.GetProfile(_context, loginAccount);
                roomChats = RoomChatDAOs.getAllRoomChats(_context)
                                .Where(r => r.TeacherProfile.Id == profile.Id).ToList();

                ViewData["Profile"] = profile;

            }
            // LoginAccount == "Student"
            else {
                StudentProfile profile = (StudentProfile) ProfileDAOs.GetProfile(_context, loginAccount);
                roomChats = RoomChatDAOs.getAllRoomChats(_context)
                                .Where(r => r.Class.StudentProfiles.Any(s => s.Id == profile.Id)).ToList();

                ViewData["Profile"] = profile;
            }
            ViewData["LoginUser"] = loginAccount;
            return View(roomChats);
        }


        public IActionResult RoomChat(int? id){

            if (HttpContext.Session.GetString("Role") != "Student"
            && HttpContext.Session.GetString("Role") != "Teacher") return Redirect("/Home/");
            if(id == null) return Redirect("/Home/");

            List<RoomChat> roomChats = null;
            RoomChat roomChat = null;

            Account loginAccount = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if(loginAccount.RoleName == "Teacher"){

                TeacherProfile profile = (TeacherProfile) ProfileDAOs.GetProfile(_context, loginAccount);
                roomChats = RoomChatDAOs.getAllRoomChats(_context)
                                .Where(r => r.TeacherProfile.Id == profile.Id).ToList();

                ViewData["Profile"] = profile;

            }
            // LoginAccount == "Student"
            else {
                StudentProfile profile = (StudentProfile) ProfileDAOs.GetProfile(_context, loginAccount);
                roomChats = RoomChatDAOs.getAllRoomChats(_context)
                                .Where(r => r.Class.StudentProfiles.Any(s => s.Id == profile.Id)).ToList();

                ViewData["Profile"] = profile;
            }

            roomChat = roomChats.FirstOrDefault(r => r.Id == id);
            if (roomChat == null) return Redirect("/Home/");

            foreach(RoomMessage item in roomChat.Messages){
                item.Account = _context.Account.Find(item.AccountID);
            }

            ViewData["RoomChat"] = roomChat;
            ViewData["LoginUser"] = loginAccount;
            return View(roomChats);
        }

    }

}