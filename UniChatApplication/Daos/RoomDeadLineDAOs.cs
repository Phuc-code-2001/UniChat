

using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Daos
{
    public class RoomDeadLineDAOs {


        public static IQueryable<RoomDeadLine> GetAll(UniChatDbContext context){
            return context.RoomDeadLines.Include(d => d.RoomChat);
        }

        public static IQueryable<RoomDeadLine> GetAllOfRoom(UniChatDbContext context, int RoomId){
            return GetAll(context).Where(d => d.RoomId == RoomId);
        }

        public static RoomDeadLine GetLastOfRoom(UniChatDbContext context, int RoomId){
            return GetAllOfRoom(context, RoomId).OrderBy(d => d.Id).LastOrDefault();
        }

    }
}