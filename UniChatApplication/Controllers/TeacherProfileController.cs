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
using System.IO;
using ExcelDataReader;

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

            teacher.Email = teacher.Email.ToLower();
            string username = AccountDAOs.getUsenameFromEmail(teacher.Email);

            if (AccountDAOs.AccountIsExisted(_context, username)){
                ViewData["Error"] = $"Account {username} existed...";
                return View(teacher);
            }

            if (_context.TeacherProfile.Any(t => t.TeacherCode == teacher.TeacherCode)) {
                ViewData["Error"] = $"TeacherCode {teacher.TeacherCode} existed...";
                return View(teacher);
            }

            teacher.Birthday = DateTime.Now.Date;

            teacher.Account = AccountDAOs.CreateAccount(username, AccountDAOs.DefaultPassword, 2);
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

        public IActionResult CreateByFile()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");

            ViewData["Result"] = TempData["Result"] ?? new List<string>();

            return View();
        }

        [HttpPost]
        public IActionResult CreateByFile(IFormFile file)
        {
            if (file == null) return RedirectToAction("Index");
            if (!file.FileName.EndsWith(".xlsx")) return BadRequest();

            //Get url To Save
            string saveRelativePath = $"/files/";

            string savePath = Directory.GetCurrentDirectory().Replace("\\", "/") + "/wwwroot" + saveRelativePath + file.FileName;

            Directory.CreateDirectory(Path.GetDirectoryName(savePath));

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            List<string> result = ProcessingData(file.FileName);
            TempData["Result"] = result;

            return RedirectToAction("CreateByFile");
        }

        private List<string> ProcessingData(string fName)
        {

            List<string> result = new List<string>();

            string fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (FileStream stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {   
                    reader.Read(); // title
                    while (reader.Read())
                    {
                        try{

                            string FullName = reader.GetValue(0).ToString();
                            string Email = reader.GetValue(1).ToString().ToLower();
                            string TeacherCode = reader.GetValue(2).ToString();
                            string Gender = reader.GetValue(3).ToString();

                            string username = AccountDAOs.getUsenameFromEmail(Email);

                            if (AccountDAOs.AccountIsExisted(_context, username))
                            {
                                result.Add($"Error: Account {username} existed...");
                                continue;
                            }

                            if (_context.TeacherProfile.Any(s => s.TeacherCode == TeacherCode))
                            {
                                result.Add($"Error: StudentCode {TeacherCode} existed...");
                                continue;
                            }

                            TeacherProfile tc = new TeacherProfile(){
                                    FullName = FullName,
                                    Email = Email,
                                    Gender = Gender.ToLower() == "male",
                                    TeacherCode = TeacherCode,
                                    Birthday = DateTime.Now
                            };

                            tc.Account = AccountDAOs.CreateAccount(username, AccountDAOs.DefaultPassword, 2);
                            
                            _context.Add(tc);
                            _context.SaveChanges();

                            result.Add($"Success: Add teacher '{FullName}' successfully.");

                        }
                        catch(NullReferenceException){
                            // End of file
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
