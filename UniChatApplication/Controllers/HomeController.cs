using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UniChatDbContext _context;

        public HomeController(ILogger<HomeController> logger, UniChatDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.errorMessage = "";

            List<Role> roles = new List<Role>();
            try
            {
                roles = _context.Role.OrderBy(item => item.Id).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage += ex.Message;
            }

            ViewBag.Roles = roles;

            List<Account> accounts = new List<Account>();
            try
            {
                accounts = _context.Account.OrderBy(item => item.Id).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage += ex.Message;
            }

            ViewBag.Accounts = accounts;

            return View();
        }

        
        public IActionResult Privacy(string name)
        {
            ViewBag.RequestMethod = HttpContext.Request.Method.ToString();
            ViewBag.RequestQuery = HttpContext.Request.Query;
            ViewBag.Name = name;
            return Json( new { name = name });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
