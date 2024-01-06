using BusinessCore.Abstract;
using Data.Models.Logins;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminAccountService _adminAccountService;
        private readonly IUserAccountService _userAccountService;
        public LoginController(IAdminAccountService adminAccountService, IUserAccountService userAccountService)
        {
            _adminAccountService = adminAccountService;
            _userAccountService = userAccountService;
        }
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(AdminAccount adminAccount)
        {

            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
    }
}
