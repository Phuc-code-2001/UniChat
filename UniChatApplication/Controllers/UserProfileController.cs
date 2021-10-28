using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniChatApplication.Daos;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Controllers
{
    public class UserProfileController : Controller
    {

        readonly UniChatDbContext _context;

        public UserProfileController(UniChatDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (HttpContext.Session.GetString("Role") == null) return Redirect("/Home/");

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);

            Account account = await _context.Account.FindAsync(id);
            if (account == null) return NotFound();

            if (account.RoleName == "Admin") return NotFound();

            Profile profile = ProfileDAOs.GetProfile(_context, account);

            ViewData["LoginUser"] = LoginUser;

            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentProfile profile)
        {
            if (HttpContext.Session.GetString("Role") == null) return Redirect("/Home/");

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);
            if (LoginUser.RoleName != "Student") return BadRequest();

            StudentProfile loginProfile = (StudentProfile) ProfileDAOs.GetProfile(_context, LoginUser);
            // Change Properties value
            loginProfile.FullName = profile.FullName;
            loginProfile.Phone = profile.Phone;
            loginProfile.Birthday = profile.Birthday;
            _context.StudentProfile.Update(loginProfile);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new {id=loginProfile.AccountID});
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAvatar(IFormFile imageFile)
        {
            if (HttpContext.Session.GetString("Role") == null) return Redirect("/Home/");

            Account LoginUser = AccountDAOs.getLoginAccount(_context, HttpContext.Session);

            if(LoginUser.RoleName == "Teacher")
            {
                TeacherProfile profile = (TeacherProfile) ProfileDAOs.GetProfile(_context, LoginUser);

                string ImageName = $"id_{profile.Id}" + Path.GetExtension(imageFile.FileName);
                //Get url To Save
                string saveRelativePath = $"/media/profiles/teacherProfiles/";

                string savePath = Directory.GetCurrentDirectory().Replace("\\", "/") + "/wwwroot" + saveRelativePath + ImageName;

                Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                using(var stream = new FileStream(savePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                profile.Avatar = saveRelativePath + ImageName;
                _context.TeacherProfile.Update(profile);
                await _context.SaveChangesAsync();
                
            }
            else if (LoginUser.RoleName == "Student") {
                StudentProfile profile = (StudentProfile) ProfileDAOs.GetProfile(_context, LoginUser);

                string ImageName = $"id_{profile.Id}" + Path.GetExtension(imageFile.FileName);
                //Get url To Save
                string saveRelativePath = $"/media/profiles/studentProfiles/";

                string savePath = Directory.GetCurrentDirectory().Replace("\\", "/") + "/wwwroot" + saveRelativePath + ImageName;

                Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                using(var stream = new FileStream(savePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                profile.Avatar = saveRelativePath + ImageName;
                _context.StudentProfile.Update(profile);
                await _context.SaveChangesAsync();
            }
            else {
                return BadRequest();
            }

            return RedirectToAction("Index", new {id=LoginUser.Id});
        }
    }
}