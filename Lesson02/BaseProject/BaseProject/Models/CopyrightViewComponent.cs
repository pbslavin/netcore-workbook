using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Models
{
    public class CopyrightViewComponent : ViewComponent, IViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

    public class SecondViewComponent : BaseViewComponent
    {
        public override IViewComponentResult Invoke()
        {
            return View();
        }

    }

    public interface IViewComponent
    {
        IViewComponentResult Invoke();
    }

    public abstract class BaseViewComponent : ViewComponent
    {
        public abstract IViewComponentResult Invoke();
    }
}
