using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Daos
{
    
    public class RoomMessagePinDAOs {

        public static IQueryable<RoomMessagePin> GetAll(UniChatDbContext context){
            return context.RoomMessagePins.Include(m => m.RoomMessage);
        }

        public static IQueryable<RoomMessagePin> GetAllMessagePinOfRoom(UniChatDbContext context, int RoomId){
            
            return GetAll(context).Where(m => m.RoomMessage.RoomID == RoomId);

        }

        public static RoomMessagePin GetMessagePinOfRoom(UniChatDbContext context, int RoomId)
        {
            return GetAllMessagePinOfRoom(context, RoomId)
                    .OrderBy(m => m.Time)
                    .LastOrDefault();
        }

    }

}