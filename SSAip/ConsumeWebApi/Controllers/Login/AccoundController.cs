using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebApi.Controllers.Login
{
    public class AccoundController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7059/api");
        private readonly HttpClient _client;
        
        public AccoundController() { 
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
