using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Daos
{
    
    public class ClassDAOs {

        public static IQueryable<Class> getAllClasses(UniChatDbContext context){
            return context.Class.Include(c => c.StudentProfiles)
                                .Include(c => c.RoomChats);
        }

        public static bool isExistedClass(UniChatDbContext context, string name){
            return context.Class.Any(c => c.Name == name);
        }

    }

}