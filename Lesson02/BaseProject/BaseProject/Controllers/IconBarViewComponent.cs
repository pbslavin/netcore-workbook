using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Controllers
{
    public class IconBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
