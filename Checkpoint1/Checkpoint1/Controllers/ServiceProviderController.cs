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
        private readonly IRepository _repository;
        private readonly ApplicationContext _context;

        public ServiceProviderController(ApplicationContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_context.ServiceProviders);
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
            //_repository.AddServiceProvider(serviceProvider);
            return View("Index", _context.ServiceProviders);
        }

        public async Task<IActionResult> Delete(ServiceProvider serviceProvider)
        {
            var itemToRemove = await _context.ServiceProviders.FindAsync(serviceProvider.ServiceProviderId);
            _context.ServiceProviders.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return View("Index", _context.ServiceProviders);
        }

        public async Task<IActionResult> AppointmentSummary(ServiceProvider serviceProvider)
        {   // Displays list of appointments grouped by day for a single service provider.
            var CurrentServiceProvider = _context.ServiceProviders.Single(s => s.ServiceProviderId == serviceProvider.ServiceProviderId);

            List<Appointment> ServiceProviderAppointments = new List<Appointment>();
            foreach (Appointment a in _context.Appointments)
                if (a.ServiceProviderId == CurrentServiceProvider.ServiceProviderId)
                {
                    ServiceProviderAppointments.Add(a);
                }

            ViewData["ServiceProviderAppointments"] = ServiceProviderAppointments.OrderBy(a => a.Day).ToList();
            ViewData["ServiceProvider"] = CurrentServiceProvider.FullName;
            ViewData["Customers"] = await _context.Customers.ToListAsync();
            return View("AppointmentSummary");
        }
    }
}