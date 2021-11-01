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
            if(id == null) return NotFound();

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            Profile LoginProfile = ProfileDAOs.GetProfile(_context, LoginUser);
            
            // Get RoomChat List
            IEnumerable<RoomChat> RoomChats = RoomChatDAOs.getAllRoomChats(_context)
                                                .Where(room => (room.TeacherProfile.AccountID == LoginUser.Id) || (room.Class.StudentProfiles.Any(student => student.AccountID == LoginUser.Id)));
            // Get main RoomChat which is selected
            RoomChat RoomChat = RoomChats.FirstOrDefault(room => room.Id == id);
            if (RoomChat == null) return Redirect("/Home/");

            
            if (LoginUser.RoleName == "Student")
            {
                // Get GroupChat List if LoginUser is student

                List<GroupChat> GroupChats = new List<GroupChat>();
                IEnumerable<GroupManage> groupDatas = GroupManageDAOs.getAllGroupData(_context).Where(d => d.StudentId == LoginProfile.Id);
                foreach (GroupManage item in groupDatas)
                {
                    GroupChats.Add(item.GroupChat);
                }
                
                ViewData["GroupChats"] = GroupChats;
            }
            else
            {
                // Get GroupChat List if LoginUser is Teacher
                IEnumerable<GroupChat> GroupChats = GroupChatDAOs.getAllGroupChats(_context)
                                                    .Where(g => g.RoomID == RoomChat.Id).OrderBy(g => g.Order)
                                                    .ToList();
                ViewData["GroupChats"] = GroupChats;
            }

            if(LoginUser.RoleName == "Student") ViewData["LoginProfile"] = (StudentProfile) LoginProfile;
            if(LoginUser.RoleName == "Teacher") ViewData["LoginProfile"] = (TeacherProfile) LoginProfile;

            ViewData["LoginUser"] = LoginUser;
            ViewData["RoomChats"] = RoomChats;
            ViewData["MessagePin"] = RoomMessagePinDAOs.GetMessagePinOfRoom(_context, RoomChat.Id);

            ViewData["Messages"] =  RoomMessageDAOs.messagesOfRoom(_context, RoomChat.Id);
            
            return View(RoomChat);
        }

        // Use to pin message into chat room
        public IActionResult PinMessage(int roomMessageId)
        {
            
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


        public IActionResult GroupChat(int? id)
        {

            if (HttpContext.Session.GetString("Role") != "Student") return Redirect("/Home/");
            if(id == null) return NotFound();

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            Profile LoginProfile = ProfileDAOs.GetProfile(_context, LoginUser);
            
            // Get RoomChat List
            IEnumerable<RoomChat> RoomChats = RoomChatDAOs.getAllRoomChats(_context)
                                                .Where(room => room.Class.StudentProfiles.Any(student => student.AccountID == LoginUser.Id));

            // Get GroupChat List
            IEnumerable<GroupChat> GroupChats = GroupChatDAOs.getAllGroupChats(_context)
                                                .Where(g => RoomChats.Any(r => r.Id == g.RoomID))
                                                .ToList();
            ViewData["GroupChats"] = GroupChats;

            // Get main GroupChat which is selected
            GroupChat GroupChat = GroupChats.FirstOrDefault(g => g.Id == id);
            if (GroupChat == null) return NotFound();


            

            if(LoginUser.RoleName == "Student") ViewData["LoginProfile"] = (StudentProfile) LoginProfile;
            if(LoginUser.RoleName == "Teacher") ViewData["LoginProfile"] = (TeacherProfile) LoginProfile;

            ViewData["LoginUser"] = LoginUser;
            ViewData["RoomChats"] = RoomChats;
            // ViewData["MessagePin"] = RoomMessagePinDAOs.GetMessagePinOfRoom(_context, RoomChat.Id);

            ViewData["Messages"] =  _context.GroupMessages.Where(m => m.GroupId == GroupChat.Id);
            
            return View(GroupChat);
        }

        

    }

}