using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebApi.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
