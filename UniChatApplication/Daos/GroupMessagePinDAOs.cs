using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Daos
{
    
    public class GroupMessagePinDAOs {

        public static IQueryable<GroupPinMessage> GetAll(UniChatDbContext context){
            return context.GroupPinMessages
                    .Include(m => m.GroupMessage);
        }

        public static IQueryable<GroupPinMessage> GetAllMessagePinOfGroup(UniChatDbContext context, int GroupId){
            
            return GetAll(context).Where(m => m.GroupMessage.GroupId == GroupId);

        }

        public static GroupPinMessage GetMessagePinOfGroup(UniChatDbContext context, int GroupId)
        {
            return GetAllMessagePinOfGroup(context, GroupId)
                    .OrderBy(m => m.Time)
                    .LastOrDefault();
        }

    }

}