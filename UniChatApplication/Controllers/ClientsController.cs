using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniChatApplication.Daos;
using UniChatApplication.Data;
using UniChatApplication.Models;

namespace UniChatApplication.Controllers
{
    public class ClientsController : Controller
    {
        readonly UniChatDbContext _context;

        public ClientsController(UniChatDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Redirect("/Home/");
        }

        public IActionResult RoomChat(int? id)
        {
            return Redirect("/Home/");
        }

        public IActionResult GroupChat(int? id){
            return Redirect("/Home/");
        }
    }
}
