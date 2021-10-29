using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniChatApplication.Models;
using UniChatApplication.Data;
using Microsoft.AspNetCore.Http;

namespace UniChatApplication.Controllers
{
     public class ContactController : Controller
    {
        private readonly UniChatDbContext _logger;

        public ContactController(UniChatDbContext logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // add new request for contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Contact obj)
        {
            if (ModelState.IsValid)
            {
                this._logger.Contacts.Add(obj);
                this._logger.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // show list of contact
        public IActionResult ContactManagement()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            IEnumerable<Contact> contactList = this._logger.Contacts;
            return View(contactList);
        }

        // view beforce delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == 0)
            {
                return NotFound();
            }
            var obj = this._logger.Contacts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //delete data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteContact(int contactId)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            Contact obj = this._logger.Contacts.Find(contactId);
            if (obj == null) return NotFound();
            this._logger.Contacts.Remove(obj);
            this._logger.SaveChanges();
            return RedirectToAction("ContactManagement");
        }

        public IActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == 0)
            {
                return NotFound();
            }
            var obj = this._logger.Contacts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateContact(Contact obj)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (ModelState.IsValid)
            {
                this._logger.Contacts.Update(obj);
                this._logger.SaveChanges();
                return RedirectToAction("ContactManagement");
            }
            return View(obj);
        }
    }
}