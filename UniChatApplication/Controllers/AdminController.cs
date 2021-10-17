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

        // Mapping Index
        public IActionResult Index()
        {

            Account loginAccount = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if(loginAccount != null){
                if(loginAccount.RoleName == "Admin"){
                    AdminProfile profile = (AdminProfile) ProfileDAOs.GetProfile(_context, loginAccount);
                    return View(profile);
                }
            }

            return Redirect("/Login/");

        }

        // Mapping to Admin Profile
        public IActionResult Details(int? id){

            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if(id == null) return Redirect("/Home/");
            AdminProfile admin =  _context.AdminProfile.Include(a => a.Account).FirstOrDefault(m => m.Id == id);
            if (admin == null) return Redirect("/Home/");
            return View(admin);

        }

    }
}
