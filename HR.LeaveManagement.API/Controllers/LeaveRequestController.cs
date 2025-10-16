using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    public class LeaveRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
