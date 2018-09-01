using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Checkpoint1.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint1.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IRepository _repository;
        private readonly ApplicationContext _context;

        public AppointmentController(ApplicationContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Customers"] = await _context.Customers.ToListAsync();
            ViewData["ServiceProviders"] = await _context.ServiceProviders.ToListAsync();
            return View(await _context.Appointments.OrderBy(a => a.Day).ThenBy(a => a.Time).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            bool hasCusts = _context.Customers.Any();
            bool hasServProvs = _context.ServiceProviders.Any();
            if (hasCusts && hasServProvs)
            {
                ViewData["Customers"] = await _context.Customers.ToListAsync();
                ViewData["ServiceProviders"] = await _context.ServiceProviders.ToListAsync();
                return View();
            }
            else
            {
                ViewBag.message = "You must create at least one customer and one service provider.";
                return View("Index", _context.Appointments);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            try
            {
                _repository.BookAppointment(appointment);
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return Redirect("Index");
            }
            catch
            {
                ViewBag.message = "That appointment is not available.";
                return Redirect("Index");
            }
        }

        public async Task<IActionResult> Delete(Appointment appointment)
        {
            ViewData["Customers"] = await _context.Customers.ToListAsync();
            var itemToRemove = await _context.Appointments.FindAsync(appointment.AppointmentId);
            _context.Appointments.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return View("Index", _context.Appointments);
        }
    }
}