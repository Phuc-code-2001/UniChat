﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Data;
using UniChatApplication.Models;
using UniChatApplication.Daos;
using Microsoft.AspNetCore.Http;

namespace UniChatApplication.Controllers
{
    public class RoomChatController : Controller
    {
        private readonly UniChatDbContext _context;

        public RoomChatController(UniChatDbContext context)
        {
            _context = context;
        }

        // GET: RoomChat
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");

            IEnumerable<RoomChat> rooms = RoomChatDAOs.getAllRoomChats(_context);
            return View(rooms);
        }

        // GET: RoomChat/Details/5
        public IActionResult Details(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(m => m.Id == id);
            if (roomChat == null) return Redirect("/Home/");

            return View(roomChat);
        }

        // GET: RoomChat/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "FullName");
            ViewData["TeacherId"] = new SelectList(_context.TeacherProfile, "Id", "FullName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomChat roomChat)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            
            if (ModelState.IsValid)
            {
                string ClassName = _context.Class.Find(roomChat.ClassId)?.Name;
                string SubjectName = _context.Subjects.Find(roomChat.SubjectId)?.FullName;

                if(ClassName == null || SubjectName == null) return Redirect("/Home/");

                if (!RoomChatDAOs.RoomChatExists(_context, roomChat.ClassId, roomChat.SubjectId)) {
                    _context.RoomChats.Add(roomChat);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else {
                    ViewData["Error"] = $"RoomChat with Class {ClassName} and Subject {SubjectName} existed.";
                }
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", roomChat.ClassId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "FullName", roomChat.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherProfile, "Id", "FullName", roomChat.TeacherId);
            return View(roomChat);
        }

        // GET: RoomChat/Edit/5
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(r => r.Id == id);
            if (roomChat == null) Redirect("/Home/");

            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", roomChat.ClassId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "FullName", roomChat.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherProfile, "Id", "FullName", roomChat.TeacherId);

            return View(roomChat);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, RoomChat roomChat)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            if (ModelState.IsValid)
            {
                string ClassName = _context.Class.First(c => c.Id == roomChat.ClassId).Name;
                string SubjectName = _context.Subjects.First(s => s.Id == roomChat.SubjectId).FullName;
                try
                {
                    _context.RoomChats.Update(roomChat);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewData["Error"] = $"RoomChat with Class {ClassName} and Subject {SubjectName} existed.";
                }
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", roomChat.ClassId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "FullName", roomChat.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherProfile, "Id", "FullName", roomChat.TeacherId);
            return View(roomChat);
        }

        // GET: RoomChat/Delete/5
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            RoomChat roomChat = RoomChatDAOs.getAllRoomChats(_context).FirstOrDefault(m => m.Id == id);
            if (roomChat == null) return Redirect("/Home/");

            return View(roomChat);
        }

        // POST: RoomChat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin") return Redirect("/Home/");
            if (id == null) return Redirect("/Home/");

            RoomChat roomChat = _context.RoomChats.Find(id);
            if(roomChat == null) return Redirect("/Home/");
            _context.RoomChats.Remove(roomChat);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
