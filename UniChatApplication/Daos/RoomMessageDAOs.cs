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
            return _context.RoomMessages.Include(m => m.Account).Include(m => m.RoomChat);
        }

        public static IEnumerable<RoomMessage> messagesOfRoom(UniChatDbContext _context, int RoomID){
            return getAll(_context).Where(m => m.RoomID == RoomID);
        }

        public static List<RoomMessage> getSlice(List<RoomMessage> _list, int a, int b){
            int size = _list.Count();
            List<RoomMessage> result = new List<RoomMessage>();
            if (a < 0 || b < 0 || b < a) return result;

            for(int i = a; i < b && i < size; i++) {
                result.Add(_list[i]);
            }

            return result;

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