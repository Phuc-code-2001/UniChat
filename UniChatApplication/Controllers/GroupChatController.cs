using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniChatApplication.Models;
using UniChatApplication.Daos;
using UniChatApplication.Data;

namespace UniChatApplication.Controllers
{
    public class GroupChatController : Controller
    {

        readonly UniChatDbContext _context;

        public GroupChatController(UniChatDbContext context)
        {
            _context = context;
        }

        // Mapping to Create GroupChat View
        public IActionResult Create(int roomId)
        {
            if (HttpContext.Session.GetString("Role") != "Student") return Redirect("/Home/");
            
            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == roomId);
            if (roomChat == null) return NotFound();

            // Check RoomChat if it includes LoginUser
            if (!roomChat.Class.StudentProfiles.Any(s => s.AccountID == LoginUser.Id)) return BadRequest();
            ViewData["RoomChat"] = roomChat;

            return View();
        }

        [HttpPost]
        public IActionResult Create(int roomId, GroupChat groupChat)
        {
            if (HttpContext.Session.GetString("Role") != "Student") return Redirect("/Home/");
            
            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == roomId);
            if (roomChat == null) return NotFound();
            ViewData["RoomChat"] = roomChat;

            // Check RoomChat if it includes LoginUser
            if (!roomChat.Class.StudentProfiles.Any(s => s.AccountID == LoginUser.Id)) return BadRequest();
            
            List<GroupChat> groupChatOfRooms = roomChat.GroupChats.OrderBy(g => g.Order).ToList();
            if (groupChatOfRooms.Any(g => g.Name == groupChat.Name))
            {
                ViewData["ErrorMessage"] = $"GroupChat with name '{groupChat.Name}' existed. Try another.";
                return View();
            }

            // Set Group Order
            groupChat.RoomID = roomChat.Id;
            int groupOrder = 1;
            foreach (GroupChat item in groupChatOfRooms)
            {
                if (groupOrder == item.Order) groupOrder++;
                else break;
            }
            groupChat.Order = groupOrder;

            // Initialize leader for group
            StudentProfile LoginProfile = (StudentProfile) ProfileDAOs.GetProfile(_context, LoginUser);

            if (GroupManageDAOs.getAllGroupData(_context).Any(m => m.StudentId == LoginProfile.Id && m.GroupChat.RoomID == roomChat.Id))
            {
                ViewData["ErrorMessage"] = $"You had a group in this room and can not create new group.";
                return View();
            }

            GroupManage groupData = new GroupManage()
            {
                GroupChat = groupChat,
                StudentProfile = LoginProfile,
                Role = true
            };

            _context.GroupManages.Add(groupData);
            _context.SaveChanges();


            return RedirectToAction("Setting", new {roomId=roomChat.Id});
        }


        // Add more student into Group of LoginUser
        public IActionResult Setting(int roomId)
        {
            
            if (HttpContext.Session.GetString("Role") != "Student") return Redirect("/Home/");
            
            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == roomId);
            if (roomChat == null) return NotFound();
            ViewData["RoomChat"] = roomChat;

            // Check RoomChat if it includes LoginUser
            if (!roomChat.Class.StudentProfiles.Any(s => s.AccountID == LoginUser.Id)) return BadRequest();

            // Check RoomChat if it include a group chat of LoginUser
            GroupManage groupData = GroupManageDAOs.getAllGroupData(_context)
                                .FirstOrDefault(d => d.StudentProfile.AccountID == LoginUser.Id && d.RoleText == "Leader");
            if (groupData == null) return NotFound();
            GroupChat GroupChat = groupData.GroupChat;

            IEnumerable<StudentProfile> studentsOfRoom = roomChat.Class.StudentProfiles;
            

            return View(GroupChat);
        }

        public IActionResult AddMember(int GroupChatId, int StudentId)
        {
            object DataResponse = new {};
            return Ok(DataResponse);
        }

    }
}