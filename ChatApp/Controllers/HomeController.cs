using ChatApp.DataAccessLayer.Interface;
using ChatApp.Hubs;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUser _userService;
        private readonly ISMSSender _smsSender;

        public HomeController(ILogger<HomeController> logger, IUser user, ISMSSender sMSSender)
        {
            _logger = logger;
            _userService = user;
            _smsSender = sMSSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            //SMSSenderDto sMSSenderDto = new SMSSenderDto();
            //sMSSenderDto.Title = "Test";
            //sMSSenderDto.Content = "Sinab korish";
            //sMSSenderDto.Recipent = "+998500727879";
            //bool a =await _smsSender.SendAsync(sMSSenderDto);
            //await Console.Out.WriteLineAsync(a.ToString());
            return View();
        }
        public async Task<IActionResult> Add(UserRegister userRegister)
        {
            Users users = userRegister;
            await _userService.Add(users);
            return RedirectToAction("Register");
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignIn(UserLogin user)
        {
            
            return RedirectToAction("ChatMessage");
        }
        public IActionResult ChatMessage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasword res)
        {
            return View();
        }
        public IActionResult OTP()
        {
            return View();
        }
    }
}
