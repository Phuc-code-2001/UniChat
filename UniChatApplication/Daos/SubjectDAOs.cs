using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Daos
{

    public class SubjectDAOs {


        public static IQueryable<Subject> getAllSubject(UniChatDbContext context){
            
            return context.Subjects.Include(s => s.RoomChats);

        }

        public static bool isExitedSubject(UniChatDbContext context, string code){
            return context.Subjects.Any(s => s.SubjectCode == code);
        }

    }
    
}