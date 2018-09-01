using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint1.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly IRepository _repository;

        public ServiceProviderController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.ServiceProviders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceProvider serviceProvider)
        {
            _repository.AddServiceProvider(serviceProvider);
            return View("Index", _repository.ServiceProviders);
        }

        public IActionResult Delete(ServiceProvider serviceProvider)
        {
            var itemToRemove = _repository.ServiceProviders.Single(s => s.ServiceProviderId == serviceProvider.ServiceProviderId);
            _repository.ServiceProviders.Remove(itemToRemove);
            return View("Index", _repository.ServiceProviders);
        }

        public IActionResult AppointmentSummary(ServiceProvider serviceProvider)
        {   // Displays list of appointments grouped by day for a single service provider.
            var CurrentServiceProvider = _repository.ServiceProviders.Single(s => s.ServiceProviderId == serviceProvider.ServiceProviderId);

            List<Appointment> ServiceProviderAppointments = new List<Appointment>();
            foreach (Appointment a in _repository.Appointments)
                if (a.ServiceProvider.FullName == CurrentServiceProvider.FullName)
                {
                    ServiceProviderAppointments.Add(a);
                }

            ViewData["ServiceProviderAppointments"] = ServiceProviderAppointments;
            ViewData["ServiceProvider"] = CurrentServiceProvider.FullName;
            return View("AppointmentSummary");
        }
    }
}