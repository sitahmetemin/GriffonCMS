using Microsoft.AspNetCore.Mvc;

namespace GriffonCMS.WebApp.Controllers
{
    public abstract class BaseCmsController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }

        public virtual IActionResult Detail()
        {
            return View();
        }

        public virtual IActionResult Add()
        {
            return View();
        }

        public virtual IActionResult Edit()
        {
            return View();
        }

        public virtual IActionResult Sort()
        {
            return View();
        }
    }
}