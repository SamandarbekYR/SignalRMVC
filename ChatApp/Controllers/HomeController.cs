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
        public IActionResult Add(UserRegister userRegister)
        {
            int result = _userService.Register(userRegister);
            if(result>=0)
                _logger.LogInformation("Malumotlar qo'shildi");
            else
            {
                _logger.LogInformation("Malumotlar qo'shishda xatolik yuz berdi");
            }
            return RedirectToAction("Register");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignIn(UserLogin user)
        {
            Users result = _userService.Login(user);
            if (result == null)
            {
                _logger.LogInformation("Tizimga kirishda xatolik yuz berdi");
            }
            else
            {

                _logger.LogInformation($"Tizimga kirdi {result!.Name}");
            }
            return RedirectToAction("ChatMessage");
        }
        public IActionResult ChatMessage()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
        public IActionResult OTP()
        {
            return View();
        }
    }
}
