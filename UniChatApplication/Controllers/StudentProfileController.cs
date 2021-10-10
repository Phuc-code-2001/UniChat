using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;
using UniChatApplication.Daos;

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
            var uniChatDbContext = _context.StudentProfile.Include(s => s.Account).Include(s => s.Class);
            return View(await uniChatDbContext.ToListAsync());
        }

        // GET: StudentProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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

        // GET: StudentProfile/Create
        public IActionResult Create()
        {
            StudentProfile st = new StudentProfile();
            return View(st);
        }

        [HttpPost]
        public ActionResult Create(string newFullName, string newEmail, string newPhone, bool newGender, string newMajor, string newStudentCode)
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
                        Phone=newPhone,
                        Gender=newGender,
                        Major=newMajor,
                        StudentCode=newStudentCode,
                        Birthday=DateTime.Now,
                        Avatar=null,
                        ClassID=null,
                        Class=null
                    };

            try {
                if (_context.Account.Any(a => a.Username == username)){
                    ViewData["Error"] = $"Account with email {newEmail} existed...";
                    
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
            if (id == null)
            {
                return NotFound();
            }

            var studentProfile = await _context.StudentProfile.FindAsync(id);
            if (studentProfile == null)
            {
                return NotFound();
            }
            ViewData["AccountID"] = new SelectList(_context.Account, "Id", "Username", studentProfile.AccountID);
            ViewData["ClassID"] = new SelectList(_context.Class, "Id", "Id", studentProfile.ClassID);
            return View(studentProfile);
        }

        // POST: StudentProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Avatar,Email,Phone,Gender,Major,Birthday,StudentCode,AccountID,ClassID")] StudentProfile studentProfile)
        {
            if (id != studentProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentProfileExists(studentProfile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountID"] = new SelectList(_context.Account, "Id", "Username", studentProfile.AccountID);
            ViewData["ClassID"] = new SelectList(_context.Class, "Id", "Id", studentProfile.ClassID);
            return View(studentProfile);
        }

        // GET: StudentProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentProfile = await _context.StudentProfile.FindAsync(id);
            _context.StudentProfile.Remove(studentProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentProfileExists(int id)
        {
            return _context.StudentProfile.Any(e => e.Id == id);
        }
    }
}
