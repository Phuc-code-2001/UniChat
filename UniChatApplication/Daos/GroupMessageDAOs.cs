using System.Collections.Generic;
using UniChatApplication.Models;
using UniChatApplication.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace UniChatApplication.Daos
{

    public class GroupMessageDAOs {


        public static IQueryable<GroupMessage> getAll(UniChatDbContext _context){
            return _context.GroupMessages
                            .Include(m => m.Account)
                            .Include(m => m.Account.StudentProfile)
                            .Include(m => m.Account.TeacherProfile)
                            .Include(m => m.GroupChat)
                            .Include(m => m.GroupChat.GroupManages);
        }

        public static IQueryable<GroupMessage> messagesOfGroup(UniChatDbContext _context, int GroupID){
            return getAll(_context).Where(m => m.GroupId == GroupID).OrderBy(m => m.TimeMessage);
        }

        public static IEnumerable<GroupMessage> Take(UniChatDbContext context, int GroupId, int start, int count)
        {
            return messagesOfGroup(context, GroupId).ToList().SkipLast(start).TakeLast(count);
        }
    
    }
    
}