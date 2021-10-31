using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniChatApplication.Daos;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Controllers
{
    public class SubjectController : Controller
    {
        readonly UniChatDbContext _context;

        public SubjectController(UniChatDbContext context)
        {
            _context = context;
        }

        // Mapping Index View of Subject Management
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");

            IEnumerable<Subject> subjects = SubjectDAOs.getAllSubject(_context).ToList();
            return View(subjects);
        }

        // Mapping Create View of Subject Management
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            return View();
        }

        // Use to get data from Create View to create a subject
        [HttpPost]
        public IActionResult Create(Subject sb)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (ModelState.IsValid)
            {
                if(SubjectDAOs.isExitedSubject(_context, sb.SubjectCode)){
                    ViewData["Error"] = $"SubjectCode {sb.SubjectCode} is existed.";
                    return View(sb);
                }
                _context.Subjects.Add (sb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sb);
        }

        // Mapping to Delete View to confirm delete a subject
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if(id == null) return Redirect("/Home/");

            Subject sb = SubjectDAOs.getAllSubject(_context).FirstOrDefault(s => s.Id == id);
            if (sb == null) return Redirect("/Home/");
            
            foreach(RoomChat item in sb.RoomChats){
                item.Class = ClassDAOs.getAllClasses(_context).FirstOrDefault(c => c.Id == item.ClassId);
                item.TeacherProfile = ProfileDAOs.getAllTeachers(_context).FirstOrDefault(c => c.Id == item.TeacherId);
                item.Class.StudentProfiles = ProfileDAOs.getAllStudents(_context).Where(c => c.ClassID == item.ClassId).ToList();
            }

            return View(sb);
        }
        
        // Confirm delete a subject
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if(id == null) return Redirect("/Home/");

            Subject sb = _context.Subjects.Find(id);
            if (sb == null) return Redirect("/Home/");
            _context.Subjects.Remove(sb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
