using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;

//[Authorize(Roles = "Administrator")]
[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
