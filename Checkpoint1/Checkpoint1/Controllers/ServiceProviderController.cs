using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Checkpoint1.Controllers
{
    public class ServiceProviderController : Controller
    {
        private Repository _repository;

        public ServiceProviderController(Repository repository)
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
            var itemToRemove = _repository.ServiceProviders.Single(r => r.Id == serviceProvider.Id);
            _repository.ServiceProviders.Remove(itemToRemove);
            return View("Index", _repository.ServiceProviders);
        }

        public IActionResult Appointments(ServiceProvider serviceProvider)
        {
            var CurrentServiceProvider = _repository.ServiceProviders.Single(r => r.Id == serviceProvider.Id);
            List<Appointment> ServiceProviderAppointments = new List<Appointment>();
            foreach (Appointment a in _repository.Appointments)
                if (a.ServiceProviderFullName == CurrentServiceProvider.FullName)
                {
                    ServiceProviderAppointments.Add(a);
                }
            ViewData["ServiceProviderAppointments"] = ServiceProviderAppointments;
            ViewData["ServiceProvider"] = CurrentServiceProvider.FullName;
            return View("Appointments");
        }
    }
}