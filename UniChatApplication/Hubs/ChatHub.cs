using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using UniChatApplication.Data;
using UniChatApplication.Models;
using UniChatApplication.Daos;
using System.Linq;
using Microsoft.AspNetCore.Http;
using UniChatApplication.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc;

namespace UniChatApplication.Hubs
{
    class ChatHub : Hub
    {
        UniChatDbContext _context;
        public ChatHub(UniChatDbContext context)
        {
            _context = context;
        }

        public async Task JoinRoom(int id){

            await Groups.AddToGroupAsync(Context.ConnectionId, $"RoomChat-{id}");
            System.Console.WriteLine($"{Context.ConnectionId} Joined RoomChat {id}");
            
        }

        public async Task SendRoomMessage(int id, int roomId, string username, string avatar, string message, string time)
        {

            await Clients.Group($"RoomChat-{roomId}").SendAsync(
                    "GetRoomMessage",
                    username,
                    message,
                    id,
                    avatar,
                    time
            );
            
            // Account account = await _context.Account.FindAsync(userId);

            // ISession session = LoginController.session;
            // Account loginUser = AccountDAOs.getLoginAccount(_context, session);
            
            // RoomChat room = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == roomId);

            // if(loginUser.Id == userId 
            // && (room.Class.StudentProfiles.Any(p => p.AccountID == userId)
            // || room.TeacherProfile.AccountID == userId)){

            //     RoomMessageDAOs.Add(_context, new RoomMessage(){
            //         AccountID = account.Id,
            //         RoomID = roomId,
            //         Content = message,
            //         TimeMessage = DateTime.Now
            //     });

            //     RoomMessage roomMessage = await _context.RoomMessages.OrderBy(r => r.Id).LastAsync();
            //     int messageId = roomMessage.Id;
                
            //     string avatar = "";
            //     if (loginUser.RoleName == "Teacher"){
            //         avatar = ((TeacherProfile) ProfileDAOs.GetProfile(_context, loginUser)).Avatar;
            //     }
            //     else if (loginUser.RoleName == "Student"){
            //         avatar = ((StudentProfile) ProfileDAOs.GetProfile(_context, loginUser)).Avatar;
            //     }

            //     await Clients.Group($"RoomChat-{roomId}").SendAsync(
            //         "GetRoomMessage",
            //         loginUser.Username,
            //         message,
            //         messageId,
            //         avatar
            //     );
            // }
        }
    }
}