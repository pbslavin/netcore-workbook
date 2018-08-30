using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Checkpoint1.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IRepository _repository;

        public AppointmentController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.Appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            bool hasCusts = _repository.Customers.Any();
            bool hasServProvs = _repository.ServiceProviders.Any();
            if (hasCusts && hasServProvs)
            {
                ViewData["Customers"] = _repository.Customers;
                ViewData["ServiceProviders"] = _repository.ServiceProviders;
                return View();
            }
            else
            {
                ViewBag.message = "You must create at least one customer and one service provider.";
                return View("Index", _repository.Appointments);
            }
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            try
            {
                _repository.BookAppointment(appointment);
                return View("Index", _repository.Appointments);
            }
            catch
            {
                ViewBag.message = "That appointment is not available.";
                return View("Index", _repository.Appointments);
            }
        }

        public IActionResult Delete(Appointment appointment)
        {
            var itemToRemove = _repository.Appointments.Single(r => r.Id == appointment.Id);
            _repository.Appointments.Remove(itemToRemove);
            return View("Index", _repository.Appointments);
        }
    }
}