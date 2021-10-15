using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Controllers
{
    public class ClassController : Controller
    {
        private readonly UniChatDbContext _context;

        public ClassController(UniChatDbContext context)
        {
            _context = context;
        }

        // GET: Class
        public async Task<IActionResult> Index()
        {
            return View(await _context.Class.Include(c => c.StudentProfiles).ToListAsync());
        }

        // GET: Class/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return Redirect("/Home/");

            var @class = await _context.Class.Include(m => m.StudentProfiles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (id == null) return Redirect("/Home/");

            return View(@class);
        }

        // GET: Class/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string Name)
        {
            
            if (_context.Class.Any(c => c.Name == Name)){
                ViewData["Error"] = $"Class {Name} existed...";
                return View();
            }

            Class new_class = new Class(){Name=Name};
            _context.Class.Add(new_class);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Class/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return Redirect("/Home/");

            var @class = await _context.Class.Include(c => c.StudentProfiles).FirstOrDefaultAsync(c => c.Id == id);
            if (@class == null) return Redirect("/Home/");
            
            IEnumerable<StudentProfile> students = _context.StudentProfile.Where(s => s.ClassID == null);
            ViewData["students"] = students;
            return View(@class);
        }

        [HttpPost]
        public void AddStudent(int? stId, int? classId){

            if (stId == null || classId == null) return;

            StudentProfile student = _context.StudentProfile.Include(s => s.Class).FirstOrDefault(s => s.Id == stId);
            Class _class = _context.Class.Find(classId);

            if (student != null && _class != null && student.Class == null) {
                student.ClassID = classId;
                _context.StudentProfile.Update(student);
                _context.SaveChanges();
            }

            // System.Console.WriteLine($"AddStudent: {stId} -> {classId}");
        }

        [HttpPost]
        public void RemoveStudent(int? stId, int? classId)
        {
            if (stId == null || classId == null) return;

            StudentProfile student = _context.StudentProfile.Include(s => s.Class).FirstOrDefault(s => s.Id == stId);
            Class _class = _context.Class.Find(classId);

            if (student != null && _class != null && student.ClassID == classId) {
                student.ClassID = null;
                student.Class = null;
                _context.StudentProfile.Update(student);
                _context.SaveChanges();
            }

            // System.Console.WriteLine($"RemoveStudent: {stId} <- {classId}");
        }

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class.Include(m => m.StudentProfiles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @class = await _context.Class.FindAsync(id);
            _context.Class.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.Id == id);
        }
    }
}
