using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BaseProject.Models;
using BaseProject.Intrastructure;

namespace BaseProject.Controllers
{

    [Route("Home")]
    public class HomeController : Controller
    {
        private static string[] allowedUsers = new []
            {
                "dan"
            };

        [Route("")]      // Combines to define the route template "Home"
        [Route("Index")] // Combines to define the route template "Home/Index"
        [Route("/")]     // Doesn't combine, defines the route template ""
        public IActionResult Index([FromQuery] string username)
        {
        //if (allowedUsers.Contains(username))
            return View();
        //else
        //    throw new NotFoundException();
        }


        [Route("About")]
        [HttpPost]
        public IActionResult About(Name name)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return Redirect(nameof(About));
        }

        [Route("About")]
        [HttpGet]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            var name = new Name()
            {
                FirstName = "Peter",
                LastName = "Slavin"
            };
            return View(name);
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("MyFormPage")]
        [HttpGet]
        public IActionResult MyFormPage()
        {
            return View();
        }

        [Route("MyFormPage")]
        [HttpPost]
        public IActionResult Index(FormDataModel formDataModel)
        {
            Repository.AddFormDataObject(formDataModel);
            return View("FormResults", Repository.FormDataObjects);
        }
    }
}
