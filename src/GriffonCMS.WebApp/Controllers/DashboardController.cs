using GriffonCMS.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GriffonCMS.WebApp.Controllers
{
    public class DashboardController : BaseCmsController
    {
        protected readonly ILogger<DashboardController> Logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(logger));

            Logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
