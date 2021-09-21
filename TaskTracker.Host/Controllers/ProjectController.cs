using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Host.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
