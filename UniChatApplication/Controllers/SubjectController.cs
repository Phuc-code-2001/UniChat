using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Controllers {

    public class SubjectController : Controller
    {

        readonly UniChatDbContext _context;

        public SubjectController(UniChatDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            IEnumerable<Subject> subjects = _context.Subjects;
            return View(subjects);
        }

        public IActionResult Create(){
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject sb){
            if (ModelState.IsValid){

                _context.Subjects.Add(sb);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(sb);
        }

    }

}