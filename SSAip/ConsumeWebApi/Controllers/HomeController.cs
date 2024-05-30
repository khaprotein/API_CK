using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;

namespace ConsumeWebApi.Controllers
{
    public class HomeController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7059/api");
        private readonly HttpClient _client;
        public HomeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index(int? page,int? id_category)
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            List<Product> list = new List<Product>();
            if(id_category != null)
            {
                list = AllProductByCategory((int)id_category);
            }
            else
            {
                list = AllProduct();
            }
            int pagesize = 12;
            int pagenumber = (page ?? 1);
            
            return View(list.ToPagedList(pagenumber, pagesize));
        }

        [HttpGet]
        public List<Product> AllProduct() {
            List<Product> list = new List<Product>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Products/GetAllProduct").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Product>>(data);
                return list;
            }
            return list;
        }

        [HttpGet]
        public List<Product> AllProductByCategory(int id_category)
        {
            List<Product> list = new List<Product>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Products/GetProductByCategory?idcategory="+id_category).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Product>>(data);
                return list;
            }
            return list;
        }

    }
}
