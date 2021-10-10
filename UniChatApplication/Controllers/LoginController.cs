using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniChatApplication.Models;
using UniChatApplication.Data;
using UniChatApplication.Daos;
using Microsoft.AspNetCore.Http;
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
            else {

                //read cookie from Request object  
                string cookieValueFromReq = Request.Cookies["login"];
                if (cookieValueFromReq != null) {
                    List<LoginCookie> cookies = _context.LoginCookies.Where(c => c.Key == cookieValueFromReq).ToList();
                    if (cookies.Count > 0){

                        if (cookies[0].ExpirationTime > DateTime.Now){

                            int userId = cookies[0].AccountID;
                            Account user = _context.Account.Find(userId);
                            if (user != null){
                                HttpContext.Session.SetString("username", user.Username);
                                return RedirectToAction("Index");
                            }
                        }
                        else {
                            _context.LoginCookies.Remove(cookies[0]);
                            _context.SaveChanges();
                            DeleteCookie();
                        }

                    }

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
                List<Account> accounts = _context.Account.Where(a => a.Username == LoginInfo.Username && a.Password == LoginInfo.Password).ToList();
                List<Account> matchedAccounts = accounts;

                if (matchedAccounts.Count > 0)
                {
                    if (remember) {

                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTime.Now.AddMinutes(30);
                        string key;

                        while(true){
                            key = CookieDaos.CreateCookieLogin();
                            if(_context.LoginCookies.Count(c => c.Key == key) == 0){
                                break;
                            }
                        }

                        Response.Cookies.Append("login", key, options);
                        _context.LoginCookies.Add(new LoginCookie(){
                            Key=key,
                            ExpirationTime=DateTime.Now.AddMinutes(30),
                            AccountID=matchedAccounts[0].Id
                            });
                        _context.SaveChanges();

                    }
                    else {
                        DeleteCookie();
                    }
                    HttpContext.Session.SetString("username", LoginInfo.Username);
                    return RedirectToAction("Index");
                }
                else
                {
                    // Thông báo tên tài khoản hoặc mật khẩu k đúng. Quay về Login
                    ViewData["loginFailed"] = "Username or Password incorect..Try again.";

                }

            }
            else {
                // Đưa thông tin trong validator qua trang Login để thông báo
                ViewData["uerror"] = validator["UsernameMessage"];
                ViewData["perror"] = validator["PasswordMessage"];
            }

            return View("Index");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            DeleteCookie();
            return Redirect("/Home/");
        }

        public void DeleteCookie(){
            string cookieValueFromReq = Request.Cookies["login"];
            List<LoginCookie> cookies = _context.LoginCookies.Where(c => c.Key == cookieValueFromReq).ToList();
            _context.LoginCookies.RemoveRange(cookies);
            _context.SaveChanges();
            Response.Cookies.Delete("login");
        }

    }
}
