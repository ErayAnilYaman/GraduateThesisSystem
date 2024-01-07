
namespace WebApplication.Controllers
{
    #region usings
    using BusinessCore.Abstract;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    #endregion
    public class AdminController : Controller
    {
        private readonly IThesisService _thesisService;
        private readonly IUniversityService _universityService;

        public AdminController(IThesisService thesisService, IUniversityService universityService)
        {
            _thesisService = thesisService;
            _universityService = universityService;

        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var result = _thesisService.GetAll();
            return View(result);
        }
        [Authorize(Roles ="admin")]
        public IActionResult Institutes() 
        {
            var result = _thesisService.GetAll();
            if (result != null)
            {
                return View(result);
            }
            return View(null);
        }
        [Authorize(Roles ="admin")]
        public IActionResult Universities() 
        {
            var result = _universityService.List();
            if (result != null)
            {
                return View(result);
            }
            return View(null);
        }
        
    }
}
