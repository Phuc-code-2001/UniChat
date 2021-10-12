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
    public class StudentProfileController : Controller
    {
        private readonly UniChatDbContext _context;

        public StudentProfileController(UniChatDbContext context)
        {
            _context = context;
        }

        // GET: StudentProfile
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            var uniChatDbContext = _context.StudentProfile.Include(s => s.Account).Include(s => s.Class);
            return View(await uniChatDbContext.ToListAsync());
        }

        // GET: StudentProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null)
            {
                return Redirect("/Home/");
            }

            var studentProfile = await _context.StudentProfile
                .Include(s => s.Account)
                .Include(s => s.Class)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentProfile == null)
            {
                return Redirect("/Home/");
            }

            return View(studentProfile);
        }

        // GET: StudentProfile/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            StudentProfile st = new StudentProfile();
            return View(st);
        }

        [HttpPost]
        public ActionResult Create(string newFullName, string newEmail, bool newGender, string newMajor, string newStudentCode)
        {
            string username = "";
            for(int i = 0; i < newEmail.Length; i++){
                if (newEmail[i] != '@'){
                    username += newEmail[i];
                }
                else break;
            }

            StudentProfile st = new StudentProfile(){
                        FullName=newFullName,
                        Email=newEmail,
                        Phone=null,
                        Gender=newGender,
                        Major=newMajor,
                        StudentCode=newStudentCode,
                        Birthday=DateTime.Now.ToLocalTime(),
                        Avatar=null,
                        ClassID=null,
                        Class=null
                    };

            try {
                if (_context.Account.Any(a => a.Username == username)){
                    ViewData["Error"] = $"Account {username} existed...";
                    
                    return View(st);
                }
            }
            catch(Exception){

            }

            Account newAccount = AccountDAOs.CreateAccount(username, AccountDAOs.DefaultPassword, 1);
            st.Account = newAccount;
            _context.Add(st);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        // GET: StudentProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null)
            {
                return Redirect("/Home/");
            }

            var studentProfile = await _context.StudentProfile.FindAsync(id);
            if (studentProfile == null)
            {
                return Redirect("/Home/");
            }
            return View(studentProfile);
        }

        // POST: StudentProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, string editFullName, bool editGender, string editMajor, string editStudentCode)
        {
            
            var studentProfile = await _context.StudentProfile.FindAsync(Id);
            studentProfile.FullName = editFullName;
            studentProfile.Gender = editGender;
            studentProfile.Major = editMajor;
            studentProfile.StudentCode = editStudentCode;
            _context.Update(studentProfile);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: StudentProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null)
            {
                return NotFound();
            }

            var studentProfile = await _context.StudentProfile
                .Include(s => s.Account)
                .Include(s => s.Class)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentProfile == null)
            {
                return NotFound();
            }

            return View(studentProfile);
        }

        // POST: StudentProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var studentProfile = _context.StudentProfile.Include(p => p.Account).FirstOrDefault(p => p.Id == id);
            _context.Account.Remove(studentProfile.Account);
            _context.StudentProfile.Remove(studentProfile);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentProfileExists(int id)
        {
            return _context.StudentProfile.Any(e => e.Id == id);
        }
    }
}
