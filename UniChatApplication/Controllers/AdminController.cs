using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        public IActionResult Edit(AdminProfile adminProfile){

            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            AdminProfile oldProfile = _context.AdminProfile.Find(adminProfile.Id);
            oldProfile.FullName = adminProfile.FullName;
            oldProfile.Phone = adminProfile.Phone;
            oldProfile.Gender = adminProfile.Gender;
            _context.AdminProfile.Update(oldProfile);
            _context.SaveChanges();
            return Redirect($"/Admin/Details/{oldProfile.Id}");
            
        }
        
        [HttpPost]
        public IActionResult UpdateAvatar(IFormFile imageFile)
        {

            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            Account loginAccount = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if(loginAccount == null || loginAccount.RoleName != "Admin") return Redirect("/Home/");
                
            AdminProfile profile = (AdminProfile) ProfileDAOs.GetProfile(_context, loginAccount);
                    
            string ImageName = $"id_{profile.Id}" + Path.GetExtension(imageFile.FileName);
            //Get url To Save
            string saveRelativePath = $"/media/profiles/adminProfiles/";

            string savePath = Directory.GetCurrentDirectory().Replace("\\", "/") + "/wwwroot" + saveRelativePath + ImageName;

            Directory.CreateDirectory(Path.GetDirectoryName(savePath));

            using(FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            profile.Avatar = saveRelativePath + ImageName;
            _context.AdminProfile.Update(profile);
            _context.SaveChanges();
            
            return Redirect($"/Admin/Details/{profile.Id}");
        }

        
        public IActionResult UpdatePassword()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            Account loginAccount = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if (loginAccount == null || loginAccount.RoleName != "Admin") return Redirect("/Home/");

            return View(loginAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePassword(string oldPassword, string newPassword)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            Account loginAccount = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if (loginAccount == null || loginAccount.RoleName != "Admin") return Redirect("/Home/");

            if (newPassword == null || newPassword.Trim() == "") return BadRequest();

            Account temp = AccountDAOs.CreateAccount(loginAccount.Username, oldPassword, loginAccount.RoleID);

            if (temp.Password == loginAccount.Password)
            {
                Account newAccountInfo = AccountDAOs.CreateAccount(loginAccount.Username, newPassword, loginAccount.RoleID);
                if (newAccountInfo.Password != loginAccount.Password)
                {
                    loginAccount.Password = newAccountInfo.Password;
                    _context.Account.Update(loginAccount);
                    _context.SaveChanges();

                    TempData["UpdatePasswordStatus"] = true;
                    TempData["UpdatePasswordMessage"] = "Update Password Success.";
                }
                else
                {
                    TempData["UpdatePasswordStatus"] = false;
                    TempData["UpdatePasswordMessage"] = "New password is the same old password. Try again.";
                }
            }
            else
            {
                TempData["UpdatePasswordStatus"] = false;
                TempData["UpdatePasswordMessage"] = "Password input incorrect. Try again.";
            }

            return Redirect("UpdatePassword");
        }

    }
}
