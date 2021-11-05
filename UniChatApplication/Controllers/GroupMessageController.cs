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

    public class GroupMessageController : Controller
    {

        readonly UniChatDbContext _context;

        public GroupMessageController(UniChatDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(int GroupId, string Message)
        {
            if (HttpContext.Session.GetString("Role") != "Student") return BadRequest();

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            GroupChat groupChat = GroupChatDAOs.getAllGroupChats(_context).FirstOrDefault(r => r.Id == GroupId);
            
            if(groupChat.GroupManages.Any(d => d.StudentId == LoginUser.StudentProfile.Id))
            {
                GroupMessage NewMessage = new GroupMessage(){
                    GroupId = GroupId,
                    AccountId = LoginUser.Id,
                    Content = Message,
                    TimeMessage = DateTime.Now
                };

                groupChat.Messages.Add(NewMessage);
                _context.SaveChanges();
                
                var response = new {
                    id=NewMessage.Id,
                    GroupId=GroupId,
                    username=LoginUser.Username,
                    avatar=ProfileDAOs.GetProfile(_context, LoginUser).Avatar,
                    message=Message,
                    time=NewMessage.TimeMessage.ToShortTimeString()
                };

                return Ok(response);
            }

            return BadRequest();

        }

    }
}