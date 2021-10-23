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
                    .Include(r => r.Class.StudentProfiles)
                    .Include(r => r.Subject)
                    .Include(r => r.TeacherProfile)
                    .Include(r => r.Messages);
        }

        public static bool RoomChatExists(UniChatDbContext context, int classId, int SubjectId)
        {
            return context.RoomChats.Any(r => r.ClassId == classId && r.SubjectId == SubjectId);
        }

    }
}