using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Daos
{
    public class RoomChatDAOs {

        public static IQueryable<RoomChat> getAllRoomChats(UniChatDbContext context){
            return context.RoomChats
                    .Include(r => r.Class)
                    .Include(r => r.Subject)
                    .Include(r => r.TeacherProfile);
        }

    }
}