using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private UniChatDbContext _context;

        public HomeController(ILogger<HomeController> logger, UniChatDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Check()
        {

            List<Account> accounts = await _context.Account
                .ToListAsync();

            List<AdminProfile> profiles = await _context.AdminProfile.ToListAsync();

            return View(profiles);
        }

    }
}
