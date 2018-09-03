using Checkpoint1.Data;
using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint1.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly IAppointmentBookingService _AppointmentBookingService;
        private readonly ApplicationContext _context;

        public ServiceProviderController(ApplicationContext context, IAppointmentBookingService AppointmentBookingService)
        {
            _context = context;
            _AppointmentBookingService = AppointmentBookingService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceProviders.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceProviderId,FirstName,LastName")] ServiceProvider serviceProvider)
        {
            _context.Add(serviceProvider);
            await _context.SaveChangesAsync();
            return View("Index", _context.ServiceProviders);
        }

        public async Task<IActionResult> Delete(ServiceProvider serviceProvider)
        {
            var itemToRemove = await _context.ServiceProviders.FindAsync(serviceProvider.ServiceProviderId);
            _context.ServiceProviders.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return View("Index", await _context.ServiceProviders.ToListAsync());
        }

        public async Task<IActionResult> AppointmentSummary(ServiceProvider serviceProvider)
        {   // Display list of appointments grouped by day for a single service provider.
            var CurrentServiceProvider = _context.ServiceProviders.Single(s => s.ServiceProviderId == serviceProvider.ServiceProviderId);

            List<Appointment> ServiceProviderAppointments = new List<Appointment>();
            foreach (Appointment a in await _context.Appointments.ToListAsync())
                if (a.ServiceProviderId == CurrentServiceProvider.ServiceProviderId)
                {
                    ServiceProviderAppointments.Add(a);
                }

            ViewData["ServiceProviderAppointments"] = ServiceProviderAppointments.OrderBy(a => a.Day).ThenBy(a => a.Time).ToList();
            ViewData["ServiceProvider"] = CurrentServiceProvider.FullName;
            ViewData["Customers"] = await _context.Customers.ToListAsync();
            return View("AppointmentSummary");
        }
    }
}