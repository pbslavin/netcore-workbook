using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Areas.Comments.Controllers
{
    [Area("Comments")]
    [Route("[area]/Notes")]
    public class NotesController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}