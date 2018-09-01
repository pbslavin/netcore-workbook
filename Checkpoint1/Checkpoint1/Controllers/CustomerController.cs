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
            //_repository.AddCustomer(customer);
            return View("Index", _context.Customers);
        }

        //[HttpPost]
        //[Route("Create")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Description,Status")] Issue issue)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(issue);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(issue);
        //}


        public async Task<IActionResult> Delete(Customer customer)
        {
            var itemToRemove = await _context.Customers.FindAsync(customer.CustomerId);
            _context.Customers.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return View("Index", _context.Customers);
        }

        //[HttpPost, ActionName("Delete")]
        //[Route("Delete/{id:int}")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var issue = await _context.Issues.FindAsync(id);
        //    _context.Issues.Remove(issue);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
    }
}