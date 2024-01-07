
namespace WebApplication.Controllers
{
    using BusinessCore.Abstract;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    #region usings
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    #endregion
    public class UserController : Controller
    {
        private readonly IThesisService _thesisService;
        private readonly IUniversityService _universityService;
        private readonly IInstituteService _instituteService;

        public UserController(IThesisService thesisService, IUniversityService universityService, IInstituteService instituteService)
        {
            _thesisService = thesisService;
            _instituteService = instituteService;
            _universityService = universityService;
        }
        [Authorize(Roles = "user")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var result = _thesisService.GetAllByUsername(User.Identity.Name.ToString());
                return View(result);
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult Add()
        {
            List<SelectListItem> universities;
            List<SelectListItem> institutes;

            universities = (from i in _universityService.List().Data
                            select new SelectListItem
                            {
                                Value = i.UNIVERSITYID.ToString(),
                                Text = i.NAME.ToString(),
                            }).ToList();
            institutes = (from i in _instituteService.List().Data
                          select new SelectListItem
                          {
                              Value = i.INSTITUTEID.ToString(),
                              Text = i.NAME.ToString()
                          }).ToList();

            ViewBag.universities = universities;
            ViewBag.institutes = institutes;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "user")]
        public IActionResult Add(Thesis thesis)
        {
            if (User.Identity.IsAuthenticated)
            {
                _thesisService.Add(thesis);
                return View();
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult Update(int thesisNumber)
        {
            var result = _thesisService.GetByNumber(thesisNumber);
            result.Data.AUTHORID = _au
            return View(result.Data);
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public IActionResult Update(Thesis thesis)
        {
            if (User.Identity.IsAuthenticated)
            {
                _thesisService.Update(thesis);
                return View();
            }
            return View();
        }


    }
}
