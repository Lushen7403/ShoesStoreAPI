using Microsoft.AspNetCore.Mvc;

namespace ShoesStore_Web.Controllers
{
    public class ShoeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
