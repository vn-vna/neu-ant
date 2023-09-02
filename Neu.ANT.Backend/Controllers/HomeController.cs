using Microsoft.AspNetCore.Mvc;
using Neu.ANT.Backend.Services;

namespace Neu.ANT.Backend.Controllers
{
    [ApiController]
    [Route("/api/test")]
    public class HomeController : Controller
    {
        private readonly UserDbService _userDb;

        public HomeController(UserDbService userDb)
        {
            _userDb = userDb;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Json(new { 
                lmfao = 0
            });
        }
    }
}
