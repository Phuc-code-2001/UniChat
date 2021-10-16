using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;
using UniChatApplication.Daos;
using Microsoft.AspNetCore.Http;

namespace UniChatApplication.Controllers
{
    public class TeacherProfileController : Controller
    {
        private readonly UniChatDbContext _context;

        public TeacherProfileController(UniChatDbContext context)
        {
            _context = context;
        }

        // GET: TeacherProfile
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            var uniChatDbContext = _context.TeacherProfile.Include(s => s.Account);
            return View(await uniChatDbContext.ToListAsync());
        }

        // GET: TeacherProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            
            if (id == null)
            {
                return Redirect("/Home/");
            }

            var teacherProfile = await _context.TeacherProfile
                .Include(s => s.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherProfile == null)
            {
                return Redirect("/Home/");
            }

            return View(teacherProfile);
        }

        // GET: TeacherProfile/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            TeacherProfile st = new TeacherProfile();
            return View(st);
        }

        [HttpPost]
        public ActionResult Create(string fullname, string email, bool newGender, string teacherCode)
        {
            string username = "";
            for(int i = 0; i < email.Length; i++){
                if (email[i] != '@'){
                    username += email[i];
                }
                else break;
            }

            TeacherProfile st = new TeacherProfile(){
                        FullName=fullname,
                        Email=email,
                        Phone=null,
                        Gender=newGender,
                        TeacherCode=teacherCode,
                        Birthday=DateTime.Now.ToLocalTime(),
                        Avatar=null,
                    };

            try {
                if (_context.Account.Any(a => a.Username == username)){
                    ViewData["Error"] = $"Account {username} existed...";
                    
                    return View(st);
                }
            }
            catch(Exception){

            }

            Account newAccount = AccountDAOs.CreateAccount(username, AccountDAOs.DefaultPassword, 2);
            st.Account = newAccount;
            _context.Add(st);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        // GET: TeacherProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null)
            {
                return Redirect("/Home/");
            }

            var teacherProfile = await _context.TeacherProfile.FindAsync(id);
            if (teacherProfile == null)
            {
                return Redirect("/Home/");
            }

            return View(teacherProfile);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, string fullname, bool editGender, string teacherCode)
        {
            
            var teacherProfile = await _context.TeacherProfile.FindAsync(Id);
            teacherProfile.FullName = fullname;
            teacherProfile.Gender = editGender;
            teacherProfile.TeacherCode = teacherCode;
            _context.Update(teacherProfile);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: TeacherProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null)
            {
                return Redirect("/Home/");
            }

            var teacherProfile = await _context.TeacherProfile
                .Include(s => s.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherProfile == null)
            {
                return Redirect("/Home/");
            }

            return View(teacherProfile);
        }

        // POST: TeacherProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacherProfile = _context.TeacherProfile.Include(p => p.Account).FirstOrDefault(p => p.Id == id);
            _context.Account.Remove(teacherProfile.Account);
            _context.TeacherProfile.Remove(teacherProfile);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherProfileExists(int id)
        {
            return _context.TeacherProfile.Any(e => e.Id == id);
        }
    }
}
