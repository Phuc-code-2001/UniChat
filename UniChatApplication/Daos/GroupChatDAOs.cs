using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Daos
{
    public class GroupChatDAOs {

        public static IQueryable<GroupChat> getAllGroupChats(UniChatDbContext context){
            return context.GroupChats
                    .Include(g => g.RoomChat)
                    .Include(g => g.RoomChat.Class)
                    .Include(g => g.Messages)
                    .Include(g => g.GroupManages);
        }
        
    }
}