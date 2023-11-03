using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Services;

namespace Neu.ANT.Backend.Controllers
{
  [ApiController]
  [Route("/api/test")]
  public class HomeController : Controller
  {
    private readonly UserInformationService _userDb;

    public HomeController(UserInformationService userDb)
    {
      _userDb = userDb;
    }

    [HttpGet]
    [Route("/")]
    public IActionResult Index()
    {
      return Json(new
      {
        status = "OK"
      });
    }
  }
}
