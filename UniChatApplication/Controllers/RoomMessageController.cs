using System;
using UniChatApplication.Models;
using UniChatApplication.Data;
using UniChatApplication.Daos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;

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
            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == RoomID);
            
            if(roomChat.TeacherProfile.AccountID == LoginUser.Id
            || roomChat.Class.StudentProfiles.Any(p => p.AccountID == LoginUser.Id))
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

    }
}