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
    public class TeacherProfileController : Controller
    {
        private readonly UniChatDbContext _context;

        public TeacherProfileController(UniChatDbContext context)
        {
            _context = context;
        }

        // Mapping to Index view of Teacher Management
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");

            IEnumerable<TeacherProfile> teachers = ProfileDAOs.getAllTeachers(_context).ToList();
            return View(teachers);
        }

        // Mapping to detail page of Teacher Management
        public IActionResult Details(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            TeacherProfile teacherProfile = ProfileDAOs.getAllTeachers(_context).FirstOrDefault(m => m.Id == id);
            if (teacherProfile == null) return Redirect("/Home/");

            foreach(RoomChat item in teacherProfile.RoomChats){
                item.Class = ClassDAOs.getAllClasses(_context).FirstOrDefault(c => c.Id == item.ClassId);
                item.Subject = SubjectDAOs.getAllSubject(_context).FirstOrDefault(s => s.Id == item.SubjectId);
            }

            return View(teacherProfile);
        }

        // Mapping to Create View of Student Management
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            return View();
        }

        // Use to get data from create view to create teacher account and profile.
        [HttpPost]
        public ActionResult Create(TeacherProfile teacher)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");

            string username = AccountDAOs.getUsenameFromEmail(teacher.Email);
            if (AccountDAOs.AccountIsExisted(_context, username)){
                ViewData["Error"] = $"Account {username} existed...";
                return View(teacher);
            }
            teacher.Birthday = DateTime.Now.Date;

            teacher.Account = AccountDAOs.CreateAccount(username, AccountDAOs.DefaultPassword, 1);
            _context.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Mapping to Edit View of Teacher Management
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            TeacherProfile teacherProfile = ProfileDAOs.getAllTeachers(_context).FirstOrDefault(p => p.Id == id);
            if (teacherProfile == null) return Redirect("/Home/");

            return View(teacherProfile);
        }

        // Use to get data from edit view to edit information for a teacher
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, TeacherProfile teacher)
        {
            
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            TeacherProfile profile = ProfileDAOs.getAllTeachers(_context).FirstOrDefault(p => p.Id == id);
            if (profile == null) return Redirect("/Home/");
            profile.FullName = teacher.FullName;
            profile.TeacherCode = teacher.TeacherCode;
            profile.Gender = teacher.Gender;

            _context.Update(profile);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // Mapping to delete view, show information to confirm delete
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            TeacherProfile teacherProfile = ProfileDAOs.getAllTeachers(_context).FirstOrDefault(p => p.Id == id);
            if (teacherProfile == null) return Redirect("/Home/");

            foreach(RoomChat item in teacherProfile.RoomChats){
                item.Class = ClassDAOs.getAllClasses(_context).FirstOrDefault(c => c.Id == item.ClassId);
                item.Subject = SubjectDAOs.getAllSubject(_context).FirstOrDefault(s => s.Id == item.SubjectId);
            }

            return View(teacherProfile);
        }

        // Confirm delete student
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            TeacherProfile teacherProfile = ProfileDAOs.getAllTeachers(_context).FirstOrDefault(p => p.Id == id);
            _context.Account.Remove(teacherProfile.Account);
            _context.TeacherProfile.Remove(teacherProfile);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
