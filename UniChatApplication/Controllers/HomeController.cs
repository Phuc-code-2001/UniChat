using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
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

        // Mapping to Home View
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") != null){
                return Redirect("/Login/");
            }

            return View();
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Use for debug, test
        public async Task<IActionResult> Check()
        {

            List<Account> accounts = await _context.Account
                .ToListAsync();

            List<AdminProfile> profiles = await _context.AdminProfile.ToListAsync();

            return View(profiles);
        }

    }
}
