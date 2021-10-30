using Microsoft.AspNetCore.Mvc;
using UniChatApplication.Data;
using UniChatApplication.Daos;
using UniChatApplication.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;

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

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            Profile LoginProfile = ProfileDAOs.GetProfile(_context, LoginUser);

            IEnumerable<RoomChat> RoomChats = RoomChatDAOs.getAllRoomChats(_context)
                                                .Where(room => (room.TeacherProfile.AccountID == LoginUser.Id) || (room.Class.StudentProfiles.Any(student => student.AccountID == LoginUser.Id)));
            
            IEnumerable<RoomDeadLine> roomDeadLineList = RoomDeadLineDAOs.GetAll(_context)
                                                            .Where(r => RoomChats.Any(rc => rc.Id == r.RoomId))
                                                            .OrderByDescending(r => r.ExpirationTime).Take(8);

            ViewData["RoomChats"] = RoomChats;
            ViewData["LoginUser"] = LoginUser;
            ViewData["RoomDeadLineList"] = roomDeadLineList;

            return View(LoginProfile);
        }


        public IActionResult RoomChat(int? id){

            if (HttpContext.Session.GetString("Role") != "Student"
            && HttpContext.Session.GetString("Role") != "Teacher") return Redirect("/Home/");
            if(id == null) return Redirect("/Home/");

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            Profile LoginProfile = ProfileDAOs.GetProfile(_context, LoginUser);

            IEnumerable<RoomChat> RoomChats = RoomChatDAOs.getAllRoomChats(_context)
                                                .Where(room => (room.TeacherProfile.AccountID == LoginUser.Id) || (room.Class.StudentProfiles.Any(student => student.AccountID == LoginUser.Id)));
            
            RoomChat RoomChat = RoomChats.FirstOrDefault(room => room.Id == id);
            if (RoomChat == null) return Redirect("/Home/");

            if(LoginUser.RoleName == "Student") ViewData["LoginProfile"] = (StudentProfile) LoginProfile;
            if(LoginUser.RoleName == "Teacher") ViewData["LoginProfile"] = (TeacherProfile) LoginProfile;

            ViewData["LoginUser"] = LoginUser;
            ViewData["RoomChats"] = RoomChats;
            ViewData["MessagePin"] = RoomMessagePinDAOs.GetMessagePinOfRoom(_context, RoomChat.Id);

            ViewData["Messages"] =  RoomMessageDAOs.messagesOfRoom(_context, RoomChat.Id);
            
            return View(RoomChat);
        }

        // Use to pin message into chat room
        public IActionResult PinMessage(int roomMessageId){
            
            RoomMessage message = RoomMessageDAOs.getAll(_context).FirstOrDefault(m => m.Id == roomMessageId);
            if (message == null) return BadRequest();

            bool CheckMessageBelongRoomOfUser = false; 

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            Profile LoginProfile = ProfileDAOs.GetProfile(_context, LoginUser);

            if(LoginUser.RoleName == "Teacher") {
                CheckMessageBelongRoomOfUser = ((TeacherProfile) LoginProfile).RoomChats
                .Any(room => room.Id == message.RoomID);
            }
            // RoleName = "Student"
            else {
                CheckMessageBelongRoomOfUser = ((StudentProfile) LoginProfile).Class.RoomChats
                .Any(room => room.Id == message.RoomID);
            }

            if (!CheckMessageBelongRoomOfUser) return BadRequest();

            
            RoomMessagePin messagePin = RoomMessagePinDAOs.GetAllMessagePinOfRoom(_context, message.RoomID).FirstOrDefault(m => m.RoomMessage.Id == roomMessageId);

            if(messagePin == null){   
                messagePin = new RoomMessagePin(){
                    RoomMessageId = roomMessageId,
                    Time = DateTime.Now
                };       
                _context.RoomMessagePins.Add(messagePin);
                _context.SaveChanges();
            }
            else {
                messagePin.Time = DateTime.Now;
                _context.RoomMessagePins.Update(messagePin);
                _context.SaveChanges();
            }
            
            return Ok(new {Content = message.Content, Time = messagePin.Time.ToShortTimeString() + " " + messagePin.Time.ToShortDateString()});
        }

    }

}