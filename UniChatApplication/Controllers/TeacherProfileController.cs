using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;
using UniChatApplication.Daos;

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
            var uniChatDbContext = _context.TeacherProfile.Include(s => s.Account);
            return View(await uniChatDbContext.ToListAsync());
        }

        // GET: TeacherProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
            TeacherProfile st = new TeacherProfile();
            return View(st);
        }

        [HttpPost]
        public ActionResult Create(string newFullName, string newEmail, bool newGender, string newTeacherCode)
        {
            string username = "";
            for(int i = 0; i < newEmail.Length; i++){
                if (newEmail[i] != '@'){
                    username += newEmail[i];
                }
                else break;
            }

            TeacherProfile st = new TeacherProfile(){
                        FullName=newFullName,
                        Email=newEmail,
                        Phone=null,
                        Gender=newGender,
                        TeacherCode=newTeacherCode,
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

        // POST: TeacherProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, string editFullName, bool editGender, string editMajor, string editTeacherCode)
        {
            
            var teacherProfile = await _context.TeacherProfile.FindAsync(Id);
            teacherProfile.FullName = editFullName;
            teacherProfile.Gender = editGender;
            teacherProfile.TeacherCode = editTeacherCode;
            _context.Update(teacherProfile);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: TeacherProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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
