using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers;

[Authorize(Roles = "Administrator")]
public class LeaveTypesController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
