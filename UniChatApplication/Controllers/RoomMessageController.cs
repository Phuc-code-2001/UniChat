using System;
using UniChatApplication.Models;
using UniChatApplication.Data;
using UniChatApplication.Daos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;

namespace UniChatApplication.Controllers
{

    public class RoomMessageController : Controller
    {

        readonly UniChatDbContext _context;

        public RoomMessageController(UniChatDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(int RoomID, string Message)
        {
            if (HttpContext.Session.GetString("Role") != "Student"
            && HttpContext.Session.GetString("Role") != "Teacher") return BadRequest();

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            Profile LoginProfile = ProfileDAOs.GetProfile(_context, LoginUser);
            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == RoomID);
            if (roomChat == null) return BadRequest();

            // Check RoomChat if it includes LoginUser
            if(roomChat.TeacherProfile.AccountID == LoginUser.Id
            || roomChat.ClassId == LoginUser.StudentProfile?.ClassID)
            {
                roomChat.Messages.Add(new RoomMessage(){
                    RoomID = RoomID,
                    RoomChat = roomChat,
                    AccountID = LoginUser.Id,
                    Account = LoginUser,
                    Content = Message,
                    TimeMessage = DateTime.Now
                });
                _context.SaveChanges();
                RoomMessage roomMessage = roomChat.Messages.OrderBy(r => r.TimeMessage).Last();

                var response = new {
                    id=roomMessage.Id,
                    roomId=roomChat.Id,
                    username=LoginUser.Username,
                    avatar=ProfileDAOs.GetProfile(_context, LoginUser).Avatar,
                    message=roomMessage.Content,
                    time=roomMessage.TimeMessage.ToShortTimeString()
                };

                return Ok(response);
            }

            return BadRequest();

        }

        public IActionResult LoadMoreRoomMessages(int RoomId)
        {
            if (HttpContext.Session.GetString("Role") != "Student"
            && HttpContext.Session.GetString("Role") != "Teacher") return BadRequest();

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            Profile LoginProfile = ProfileDAOs.GetProfile(_context, LoginUser);
            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == RoomId);

            // Check RoomChat if it includes LoginUser
            if(roomChat.TeacherProfile.AccountID == LoginUser.Id
            || roomChat.ClassId == LoginUser.StudentProfile?.ClassID)
            {
                int NumberOfMessageSended = HttpContext.Session.GetInt32($"Room{RoomId}NumberOfMessageSended") ?? 0;
                // Main load messages statement
                IEnumerable<RoomMessage> RoomMessages = RoomMessageDAOs.Take(_context, RoomId, NumberOfMessageSended, BoxController.numberOfMessagesOnEachLoad).Reverse();

                List<object> messages = new List<object>();
                foreach (RoomMessage item in RoomMessages)
                {
                    // username, message, messageId, avatar, time
                    object message = new {
                        id=item.Id,
                        username=item.Account.Username,
                        message=item.Content,
                        avatar=ProfileDAOs.GetProfile(_context, item.Account).Avatar,
                        time=item.TimeMessage.ToShortTimeString()
                    };

                    messages.Add(message);
                }

                HttpContext.Session.SetInt32($"Room{RoomId}NumberOfMessageSended", NumberOfMessageSended + RoomMessages.Count());

                return Ok(messages);
            }
            
            return BadRequest();

        }

    }
}