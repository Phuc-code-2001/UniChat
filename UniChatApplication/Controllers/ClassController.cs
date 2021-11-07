using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Daos;
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

        // Mapping to ClassManagement - Index
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");

            IEnumerable<Class> classes = ClassDAOs.getAllClasses(_context).ToList();
            return View(classes);
        }

        // GET: Class/Details/5
        public IActionResult Details(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if(id == null) return Redirect("/Home/");

            Class c = ClassDAOs.getAllClasses(_context).FirstOrDefault(c => c.Id == id);
            if(c == null) return Redirect("/Home/");

            ViewData["RoomChats"] = RoomChatDAOs.getAllRoomChats(_context).Where(r => r.ClassId == id);

            return View(c);
        }

        // Mapping to ClassManagement - Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");

            return View();
        }

        // Get data from view and create Class
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Class c)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");

            if (ClassDAOs.isExistedClass(_context, c.Name)){
                ViewData["Error"] = $"Class {c.Name} existed.";
                return View(c);
            }

            _context.Class.Add(c);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Mapping to ClassManagement - Edit
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            Class c = ClassDAOs.getAllClasses(_context).FirstOrDefault(c => c.Id == id);
            if (c == null) return Redirect("/Home/");
            
            IEnumerable<StudentProfile> students = ProfileDAOs.getAllStudents(_context).Where(s => s.ClassID == null);
            ViewData["students"] = students;

            return View(c);
        }

        // Use to add a student to a class
        [HttpPost]
        public void AddStudent(int? stId, int? classId){

            if (stId == null || classId == null) return;

            StudentProfile student = ProfileDAOs.getAllStudents(_context).FirstOrDefault(s => s.Id == stId);
            Class c = _context.Class.FirstOrDefault(c => c.Id == classId);

            if (student != null && c != null && student.Class == null) {
                student.ClassID = classId;
                _context.StudentProfile.Update(student);
                _context.SaveChanges();
            }

            // System.Console.WriteLine($"AddStudent: {stId} -> {classId}");
        }

        // Use to remove a student to a class
        [HttpPost]
        public void RemoveStudent(int? stId, int? classId)
        {
            if (stId == null || classId == null) return;

            StudentProfile student = ProfileDAOs.getAllStudents(_context).FirstOrDefault(s => s.Id == stId);
            Class c =_context.Class.FirstOrDefault(c => c.Id == classId);

            if (student != null && c != null && student.ClassID == classId) {
                student.ClassID = null;
                student.Class = null;
                _context.StudentProfile.Update(student);
                _context.SaveChanges();
            }

            // System.Console.WriteLine($"RemoveStudent: {stId} <- {classId}");
        }

        // Mapping to ClassManagment - Delete
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if(id == null) return Redirect("/Home/");

            Class c = ClassDAOs.getAllClasses(_context).FirstOrDefault(c => c.Id == id);
            if(c == null) return Redirect("/Home/");

            ViewData["RoomChats"] = RoomChatDAOs.getAllRoomChats(_context).Where(r => r.ClassId == id);

            return View(c);
        }

        
        // Use to delete a class
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if(id == null) return Redirect("/Home/");

            Class c = ClassDAOs.getAllClasses(_context).FirstOrDefault(c => c.Id == id);
            if(c == null) return Redirect("/Home/");

            _context.Class.Remove(c);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
