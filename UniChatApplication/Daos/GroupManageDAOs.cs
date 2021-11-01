

using System.Linq;
using UniChatApplication.Models;
using UniChatApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace UniChatApplication.Daos
{

    public class GroupManageDAOs
    {
        
        public static IQueryable<GroupManage> getAllGroupData(UniChatDbContext context)
        {
            return context.GroupManages
                            .Include(m => m.GroupChat)
                            .Include(m => m.GroupChat.GroupManages)
                            .Include(m => m.StudentProfile);
        }

    }
    
}