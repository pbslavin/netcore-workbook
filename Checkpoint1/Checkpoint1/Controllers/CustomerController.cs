using Checkpoint1.Data;
using Checkpoint1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository _repository;
        private readonly ApplicationContext _context;

        public CustomerController(ApplicationContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_context.Customers);
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