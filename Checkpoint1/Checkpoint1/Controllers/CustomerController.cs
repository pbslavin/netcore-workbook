using Checkpoint1.Data;
using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IAppointmentBookingService _AppointmentBookingService;
        private readonly ApplicationContext _context;

        public CustomerController(ApplicationContext context, IAppointmentBookingService AppointmentBookingService)
        {
            _context = context;
            _AppointmentBookingService = AppointmentBookingService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName")] Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return View("Index", _context.Customers);
        }

        public async Task<IActionResult> Delete(Customer customer)
        {
            var itemToRemove = await _context.Customers.FindAsync(customer.CustomerId);
            _context.Customers.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return View("Index", _context.Customers);
        }
    }
}