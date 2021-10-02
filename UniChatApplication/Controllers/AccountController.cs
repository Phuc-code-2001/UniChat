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
    public class AccountController : Controller
    {
        private readonly UniChatDbContext _context;

        public AccountController(UniChatDbContext context)
        {
            _context = context;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
            var uniChatDbContext = _context.Account.Include(a => a.Role);
            return View(await uniChatDbContext.ToListAsync());
        }

        // GET: Account/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            Account new_account = new Account() { Role_id = 1 };
            ViewData["Role_id"] = new SelectList(_context.Role, "Id", "Name", new_account.Role_id);
            ViewBag.UMessage = string.Empty;
            ViewBag.PMessage = string.Empty;
            ViewBag.Password = string.Empty;
            ViewBag.RMessage = string.Empty;
            return View(new_account);
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string Username, string Password, int Role_id)
        {
            Account new_account = new Account() { Username = Username, Password = Password, Role_id = Role_id };
            if (new_account.IsValid())
            {
                _context.Add(new_account);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Role_id"] = new SelectList(_context.Role, "Id", "Name", new_account.Role_id);
            ViewBag.UMessage = new_account.InvalidMessages["Username"];
            ViewBag.PMessage = new_account.InvalidMessages["Password"];
            ViewBag.Password = Password;
            ViewBag.RMessage = new_account.InvalidMessages["Role"];
            return View(new_account);
        }

        // GET: Account/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Account account = _context.Account.Find(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Username, Password, Role_id")] Account account)
        {
            if (id != account.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Account.FindAsync(id);
            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.Id == id);
        }
    }
}
