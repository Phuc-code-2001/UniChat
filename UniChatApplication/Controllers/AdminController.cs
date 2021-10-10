using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniChatApplication.Daos;
using UniChatApplication.Data;
using UniChatApplication.Models;


namespace UniChatApplication.Controllers
{
    public class AdminController : Controller
    {

        readonly UniChatDbContext _context;

        public AdminController(UniChatDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ISession session = HttpContext.Session;
            string username =  session.GetString("username");

            if(username != null && username != ""){
                Account account = await _context.Account.FirstOrDefaultAsync(a => a.Username == username);
                
                if (account.RoleName == "Admin")
                {
                    AdminProfile profile = _context.AdminProfile.FirstOrDefault(p => (p.AccountID == account.Id));
                    return View(profile);
                }
            }

            
            return Redirect("/Login/");

        }

        public IActionResult Logout(){
            
            HttpContext.Session.Remove("username");
            return Redirect("/Home/");
        }

    }
}
