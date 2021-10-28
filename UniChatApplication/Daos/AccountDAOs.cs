using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniChatApplication.Models;
using UniChatApplication.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace UniChatApplication.Daos
{
    public class AccountDAOs
    {

        public static string DefaultPassword = "123456";

        public static Account CreateAccount(string username, string password, int role){
            
            var md5Hash = MD5.Create();
            
            // Byte array representation of source string
            var sourceBytes = Encoding.UTF8.GetBytes(password);

            // Generate hash value(Byte Array) for input data
            var hashBytes = md5Hash.ComputeHash(sourceBytes);

            // Convert hash byte array to string
            var hashed = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

            return new Account(){Username = username, Password=hashed, RoleID=role};

        }

        public static bool AddAccount(UniChatDbContext context, Account account){
            try
            {
                context.Account.Add(account);
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AccountIsExisted(UniChatDbContext context, string username){
            return context.Account.Any(a => a.Username == username);
        }

        public static Dictionary<string, string> AccountValidate(string username, string password){

            var result = new Dictionary<string, string>();
            result["UsernameMessage"] = "";
            result["PasswordMessage"] = "";

            if(username == null || username.Trim().Length == 0) result["UsernameMessage"] = "Username can not be blank.";
            if(password == null || password.Trim().Length == 0) result["PasswordMessage"] = "Password can not be blank.";

            return result;

        }

        public static Account getLoginAccount(UniChatDbContext context, ISession session){

            string username = session.GetString("username");

            if (username != null && username != "")
            {
                Account account = context.Account
                                    .Include(m => m.AdminProfile)
                                    .Include(m => m.StudentProfile)
                                    .Include(m => m.TeacherProfile)
                                    .FirstOrDefault(a => a.Username == username);
                return account;
            }
            
            return null;
        }

        public static string getUsenameFromEmail(string email){
            string username = "";
            for(int i = 0; i < email.Length; i++){
                if (email[i] != '@'){
                    username += email[i];
                }
                else break;
            }
            return username;
        }

        public static IQueryable<Account> getAllStudentAccount(UniChatDbContext context) {
            return context.Account
                    .Include(a => a.RoomMessages)
                    .Where(a => a.RoleName == "Student");
        }

        public static IQueryable<Account> getAllTeacherAccount(UniChatDbContext context) {
            return context.Account
                    .Include(a => a.RoomMessages)
                    .Where(a => a.RoleName == "Teacher");
        }

    }
}
