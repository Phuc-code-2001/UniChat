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

        public async Task SendMessage(string username, string message, int roomId)
        {
            
            Account account = await _context.Account.FirstOrDefaultAsync(a => a.Username == username);
            await _context.RoomMessages.AddAsync(new RoomMessage(){
                AccountID = account.Id,
                RoomID = roomId,
                Content = message,
                TimeMessage = DateTime.Now
            });
            await _context.SaveChangesAsync();

            await Clients.Group($"RoomChat-{roomId}").SendAsync("GetRoomMessage", username, message);
        }

    }
    
}