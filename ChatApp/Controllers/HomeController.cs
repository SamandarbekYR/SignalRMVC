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

        public HomeController(ILogger<HomeController> logger, IUser user)
        {
            _logger = logger;
            _userService = user;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
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
        ////////////////[HttpPost]
        ////////////////public async Task<IActionResult> ChatMessage(Users Connection)
        ////////////////{
        ////////////////    _sendMessage.SendMessageToAll(Connection.Name, "sfe");
        ////////////////    return View();
        ////////////////}
    }
}
