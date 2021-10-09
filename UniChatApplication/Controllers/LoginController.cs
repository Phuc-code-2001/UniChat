using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniChatApplication.Models;
using UniChatApplication.Data;
using UniChatApplication.Daos;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace UniChatApplication.Controllers
{
    public class LoginController : Controller
    {

        readonly UniChatDbContext _context;

        public LoginController(UniChatDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string username = HttpContext.Session.GetString("username");
            if (username != null){
                Account account = await _context.Account.FirstOrDefaultAsync(a => a.Username == username);
                if (account.RoleName == "Admin"){

                    return Redirect("/Admin/");
                }
                if (account.RoleName == "Teacher"){
                    
                    return Redirect("/Teacher/");
                }

                if (account.RoleName == "Student"){

                    return Redirect("/Student/");
                }
                
            }


            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password, bool remember)
        {

            var validator = AccountDAOs.AccountValidate(username, password);

            if (validator["UsernameMessage"] == string.Empty && validator["PasswordMessage"] == string.Empty)
            {

                Account LoginInfo = AccountDAOs.CreateAccount(username.Trim(), password.Trim(), -1);
                List<Account> matchedAccounts = _context.Account
                .Where(a => a.Username == LoginInfo.Username && a.Password == LoginInfo.Password).ToList();

                if (matchedAccounts.Count > 0)
                {
                    HttpContext.Session.SetString("username", LoginInfo.Username);
                }
                else
                {
                    // Thông báo tên tài khoản hoặc mật khẩu k đúng. Quay về Login


                }

            }
            else {
                // Đưa thông tin trong validator qua trang Login để thông báo
                ViewData["uerror"] = validator["UsernameMessage"];
                ViewData["perror"] = validator["PasswordMessage"];
            }

            return RedirectToAction("Index");

        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                HttpContext.Session.Remove("username");
            }
            return Redirect("/Home/");
        }

    }
}
