using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;
using System.Collections.Generic;

namespace ConsumeWebApi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class _UserController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7059/api");
        private readonly HttpClient _client;
        public _UserController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index(int? page,string? s)
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            List<User> list = new List<User>();
            if (s != null)
            {
                
            }
            else
            {
                list = AllUser();
            }
            int pagesize = 12;
            int pagenumber = (page ?? 1);
            return View(list.ToPagedList(pagenumber,pagesize));
        }

        public List<User> AllUser()
        {
            List<User> list = new List<User>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress+ "/User/GetAllUser").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<User>>(data);

                return list;
            }
            return list;
        }

        public List<User> UsersByRoleID(string id_role)
        {
            List<User> list = new List<User>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/User/GetAllUser").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<User>>(data);

                return list;
            }
            return list;
        }


    }
}
