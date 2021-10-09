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
            Account account = await _context.Account.FirstOrDefaultAsync(a => a.Username == username);
            
            if (account.RoleName == "Admin")
            {
                var profile = await _context.AdminProfile.Include(p => p.Account)
                    .FirstOrDefaultAsync(p => p.AccountID == account.Id);
                return View(profile);
            }
            
            return RedirectToRoute("Error");

        }

    }
}
