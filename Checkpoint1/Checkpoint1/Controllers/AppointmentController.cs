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
        private readonly IAppointmentBookingService _AppointmentBookingService;
        private readonly ApplicationContext _context;

        public AppointmentController(ApplicationContext context, IAppointmentBookingService AppointmentBookingService)
        {
            _context = context;
            _AppointmentBookingService = AppointmentBookingService;
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
                ViewData["message"] = "You must create at least one customer and one service provider.";
                return View("Index", _context.Appointments);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,Day,Time,CustomerId,ServiceProviderId")] Appointment appointment)
        {
            try
            {
                _AppointmentBookingService.BookAppointment(appointment, _context);
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return Redirect("Index");
            }
            catch
            {
                ViewData["Customers"] = await _context.Customers.ToListAsync();
                ViewData["ServiceProviders"] = await _context.ServiceProviders.ToListAsync();
                ViewData["message"] = "That appointment is not available.";
                return View("Index", await _context.Appointments.OrderBy(a => a.Day).ThenBy(a => a.Time).ToListAsync());
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