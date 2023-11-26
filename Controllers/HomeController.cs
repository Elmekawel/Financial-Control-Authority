using MICLifePortal.Common;
using MICLifePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MICLifePortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ITokenService tokenService)
        {
            _logger = logger;
            _context = context;
            _tokenService = tokenService;
        }

        public IActionResult Index()
        {
            //var accessToken = _tokenService.GetAccessToken();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User loguser)
        {
            if (ModelState.IsValid)
            {
                var obuser = _context.Users.FirstOrDefault(x => x.UserName == loguser.UserName && x.Password == loguser.Password);

                if (obuser != null)
                {
                    int roleID = obuser.RoleID;

                    if (roleID == 1)
                    {
                        HttpContext.Session.SetString("role", "Manager");
                        return RedirectToAction("Index", "Home");
                    }
                    else if (roleID == 2)
                    {
                        HttpContext.Session.SetString("role", "Admin");
                        return RedirectToAction("Index", "Home");
                    }
                    else if (roleID == 3)
                    {
                        HttpContext.Session.SetString("role", "User");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.SetString("role", "LessValidity");
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View();
        }
    }
}