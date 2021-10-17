using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;
using UniChatApplication.Daos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace UniChatApplication.Controllers
{
    public class StudentProfileController : Controller
    {
        private readonly UniChatDbContext _context;

        public StudentProfileController(UniChatDbContext context)
        {
            _context = context;
        }

        // Mapping to Index view of Student Management
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            IEnumerable<StudentProfile> students = ProfileDAOs.getAllStudents(_context).ToList();
            return View(students);
        }

        // Mapping to detail page of Student Management
        public IActionResult Details(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            StudentProfile student = ProfileDAOs.getAllStudents(_context).FirstOrDefault(m => m.Id == id);
            if (student == null) return Redirect("/Home/");

            return View(student);
        }

        // Mapping to Create View of Student Management
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            return View();
        }

        // Use to get data from create view to create student account and profile.
        [HttpPost]
        public ActionResult Create(StudentProfile student)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");

            string username = AccountDAOs.getUsenameFromEmail(student.Email);
            if (AccountDAOs.AccountIsExisted(_context, username)){
                ViewData["Error"] = $"Account {username} existed...";
                return View(student);
            }
            student.Birthday = DateTime.Now.Date;

            student.Account = AccountDAOs.CreateAccount(username, AccountDAOs.DefaultPassword, 1);
            _context.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Mapping to Edit View of Student Management
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            StudentProfile studentProfile = ProfileDAOs.getAllStudents(_context).FirstOrDefault(p => p.Id == id);
            if (studentProfile == null) return Redirect("/Home/");

            return View(studentProfile);
        }

        // Use to get data from edit view to edit information for a student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, StudentProfile student)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            StudentProfile profile = ProfileDAOs.getAllStudents(_context).FirstOrDefault(p => p.Id == id);
            if (profile == null) return Redirect("/Home/");
            profile.FullName = student.FullName;
            profile.StudentCode = student.StudentCode;
            profile.Major = student.Major;
            profile.Gender = student.Gender;

            _context.Update(profile);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Mapping to delete view, show information to confirm delete
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            StudentProfile studentProfile = ProfileDAOs.getAllStudents(_context).FirstOrDefault(p => p.Id == id);
            if (studentProfile == null) return Redirect("/Home/");

            return View(studentProfile);
        }

        // Confirm delete student
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            StudentProfile studentProfile = ProfileDAOs.getAllStudents(_context).FirstOrDefault(p => p.Id == id);
            _context.Account.Remove(studentProfile.Account);
            _context.StudentProfile.Remove(studentProfile);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}
