using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Daos
{
    public class RoomDeadLineDAOs {


        public static IEnumerable<RoomDeadLine> GetAll(UniChatDbContext context){
            return context.RoomDeadLines.Include(d => d.RoomChat)
                                        .Include(d => d.RoomChat.Class)
                                        .Include(d => d.RoomChat.Subject)
                                        .Include(d => d.RoomChat.TeacherProfile);
        }

        public static IEnumerable<RoomDeadLine> GetLimit(UniChatDbContext context, int limit)
        {
            return context.RoomDeadLines.Include(d => d.RoomChat)
                                        .Include(d => d.RoomChat.Class)
                                        .Include(d => d.RoomChat.Class.StudentProfiles)
                                        .Include(d => d.RoomChat.Subject)
                                        .Include(d => d.RoomChat.TeacherProfile)
                                        .OrderBy(d => d.Id)
                                        .Take(limit);
        }

        public static IEnumerable<RoomDeadLine> GetAllOfRoom(UniChatDbContext context, int RoomId){
            return GetAll(context).Where(d => d.RoomId == RoomId);
        }

        public static RoomDeadLine GetLastOfRoom(UniChatDbContext context, int RoomId){
            return GetAllOfRoom(context, RoomId).OrderBy(d => d.Id).LastOrDefault();
        }

    }
}