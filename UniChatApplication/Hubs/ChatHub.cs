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

        public async Task JoinGroup(int id){

            await Groups.AddToGroupAsync(Context.ConnectionId, $"GroupChat-{id}");
            System.Console.WriteLine($"{Context.ConnectionId} Joined GroupChat {id}");
            
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
        }

        public async Task SendGroupMessage(int id, int groupId, string username, string avatar, string message, string time)
        {

            await Clients.Group($"GroupChat-{groupId}").SendAsync(
                    "GetGroupMessage",
                    username,
                    message,
                    id,
                    avatar,
                    time
            );
        }
    }
}