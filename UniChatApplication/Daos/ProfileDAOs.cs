using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Daos
{
    public class ProfileDAOs
    {
        /// <summary>
        /// Get Profile from Account 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="account"></param>
        /// <returns>Profile of given Account</returns>
        public static Profile GetProfile(UniChatDbContext context, Account account)
        {
            if (account.RoleName == "Student")
            {
                StudentProfile profile = context.StudentProfile
                                        .Include(p => p.Account)
                                        .Include(p => p.Class)
                                        .Include(p => p.Class.RoomChats)
                                        .Include(p => p.Class.StudentProfiles)
                                        .Where(p => p.AccountID == account.Id)
                                        .FirstOrDefault();
                return profile;
            }
            if (account.RoleName == "Teacher")
            {
                TeacherProfile profile = context.TeacherProfile
                                        .Include(p => p.Account)
                                        .Include(p => p.RoomChats)
                                        .Where(p => p.AccountID == account.Id)
                                        .FirstOrDefault();
                return profile;
            }
            if (account.RoleName == "Admin")
            {
                AdminProfile profile =
                    context.AdminProfile
                        .Include(p => p.Account)
                        .Where(p => p.AccountID == account.Id)
                        .FirstOrDefault();
                return profile;
            }
            return null;
        }
        /// <summary>
        /// Get All Profile of Students
        /// </summary>
        /// <param name="context"></param>
        /// <returns>List of StudentProfile</returns>
        public static IQueryable<StudentProfile> getAllStudents(UniChatDbContext context)
        {

            return context.StudentProfile
                    .Include(p => p.Account)
                    .Include(p => p.Class)
                    .Include(p => p.GroupManages);
        }
        /// <summary>
        /// get All Profile of Teachers
        /// </summary>
        /// <param name="context"></param>
        /// <returns>List of TeacherProfile</returns>
        public static IQueryable<TeacherProfile> getAllTeachers(UniChatDbContext context)
        {

            return context.TeacherProfile
                    .Include(p => p.Account)
                    .Include(p => p.RoomChats);
        }

    }
}
