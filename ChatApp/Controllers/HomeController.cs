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
            if (userRegister.Phone[0] != '+')
            {
                return RedirectToAction("Register");
            }
            for(int i = 1; i < userRegister.Phone.Length; i++)
            {
                if (char.IsDigit(userRegister.Phone[i]))
                {
                    continue;
                }
                return RedirectToAction("Register");
            }
            if(userRegister.Password.Length < 8 || userRegister.Phone.Length != 13)
            {
                return RedirectToAction("Register");
            }
            int result = _userService.Register(userRegister);
            if (result >= 0)
            {
                _logger.LogInformation("Malumotlar qo'shildi");
                return RedirectToAction("Login");
            }
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
            if (result.Id == 0)
            {
                _logger.LogInformation("Tizimga kirishda xatolik yuz berdi");
                return RedirectToAction("Register");
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
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasword res)
        {
            var result = _userService.ResetParol(res);
            if(result)
                return RedirectToAction("Login");
            return View();
        }
        public IActionResult OTP()
        {
            return View();
        }
    }
}
