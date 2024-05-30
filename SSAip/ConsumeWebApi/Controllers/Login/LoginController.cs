using ConsumeWebApi.Models;
using ConsumeWebApi.Sessions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;



namespace ConsumeWebApi.Controllers.Login
{
    public class LoginController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7059/api");
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _context; 
        public LoginController(IHttpContextAccessor contextAccessor)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _context = contextAccessor;
        }
        public ActionResult Index()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string pass)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                TempData["ErrorMessage"] = "Email và mật khẩu không được để trống!";
                return RedirectToAction("Index", "Login");
            }

            try
            {
                User user = null;
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/User/GetUserLogin?email={email}&pass={pass}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(data);

                    

                    if (user != null)
                    {
                        _context.HttpContext.Session.SetString("userID", user.UserId);
                        _context.HttpContext.Session.SetString("userName", user.Name);
                        _context.HttpContext.Session.SetString("userEmail", user.Email);
                        _context.HttpContext.Session.SetString("userPass", user.Password);
                        _context.HttpContext.Session.SetString("userAdress", user.Address);
                        if (user.RoleId == "R001") {
                            TempData["SuccessMessage"] = "Chào Mừng " + user.Name;
                            return RedirectToAction("Index", "_User", new { area = "Admin" });
                        }
                        

                        TempData["SuccessMessage"] = "Chào Mừng " + user.Name;
                        return RedirectToAction("Index", "Home");
                    }
                }

                TempData["ErrorMessage"] = "Email hoặc mật khẩu không đúng!";
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                TempData["ErrorMessage"] = "Đã xảy ra lỗi trong quá trình đăng nhập!";
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult signout()
        {
            // Xóa Session user
            _context.HttpContext.Session.Remove("userID");
            _context.HttpContext.Session.Remove("userName");
            _context.HttpContext.Session.Remove("userEmail");
            _context.HttpContext.Session.Remove("userPass");
            _context.HttpContext.Session.Remove("userAdress");

            // Chuyển hướng đến trang chính sau khi đăng xuất
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            return View();
        }
        public ActionResult ResetPassword(string email)
        {
            User user = new User();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/User/GetUserByEmail?email=" + email).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Email = email;
                return View("ForgotPassword");
            }
            else
            {
                TempData["ErrorMessage"] = "Email ko tồn tại!";
                return RedirectToAction("ForgotPassword", "Login");
            }
        }
    }
}
