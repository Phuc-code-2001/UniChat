using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using UniChatApplication.Data;

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

            await Clients.Group($"RoomChat-{roomId}").SendAsync("GetRoomMessage", username, message);
        }

    }
    
}