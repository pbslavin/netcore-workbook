using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Checkpoint1.Controllers
{
    public class AppointmentController : Controller
    {
        private Repository _repository;

        public AppointmentController(Repository repository)
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
            return View();
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