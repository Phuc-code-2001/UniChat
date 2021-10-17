using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniChatApplication.Models;
using UniChatApplication.Data;
using System.Security.Cryptography;
using System.Text;

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
        // Add account
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
        // check account existing
        public static bool AccountIsExisted(UniChatDbContext context, string username){
            try {
                return context.Account.Where(a => a.Username == username).ToList().Count > 0;
            }
            catch (Exception){
                return true;
            }
        }
        // validation login
        public static Dictionary<string, string> AccountValidate(string username, string password){

            var result = new Dictionary<string, string>();
            result["UsernameMessage"] = "";
            result["PasswordMessage"] = "";

            if(username == null || username.Trim().Length == 0) result["UsernameMessage"] = "Username can not be blank.";
            if(password == null || password.Trim().Length == 0) result["PasswordMessage"] = "Password can not be blank.";

            return result;

        }

    }
}
