using System.Linq;
using System.Threading.Tasks;
using BaseProject.Data;
using BaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly ApplicationContext _context;

        public UserController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.AsNoTracking().Where(u => u.FirstName.Length > 3).ToListAsync());
        }

        [HttpGet]
        [Route("Create")]
        // GET: Users
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [Route("Create")]
        // GET: Users
        public async Task<IActionResult> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction();
        }
    }
}
