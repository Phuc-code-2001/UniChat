using System.Collections.Generic;
using UniChatApplication.Models;
using UniChatApplication.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace UniChatApplication.Daos
{

    public class RoomMessageDAOs {


        public static IEnumerable<RoomMessage> getAll(UniChatDbContext _context){
            return _context.RoomMessages
                            .Include(m => m.Account)
                            .Include(m => m.Account.StudentProfile)
                            .Include(m => m.Account.TeacherProfile)
                            .Include(m => m.RoomChat);
        }

        public static IEnumerable<RoomMessage> messagesOfRoom(UniChatDbContext _context, int RoomID){
            return getAll(_context).Where(m => m.RoomID == RoomID).OrderBy(m => m.TimeMessage);
        }

        public static bool Add(UniChatDbContext _context, RoomMessage message){
            try{
                _context.RoomMessages.Add(message);
                _context.SaveChanges();
                return true;
            }
            catch(Exception){
                return false;
            }
        }

        public static bool Remove(UniChatDbContext _context, RoomMessage message){
            try{
                _context.RoomMessages.Remove(message);
                _context.SaveChanges();
                return true;
            }
            catch(Exception){
                return false;
            }
        }
    
    }
    
}