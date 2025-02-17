using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUi.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }   
    }
}
