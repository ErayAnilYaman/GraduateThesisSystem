
namespace WebApplication.Controllers
{
    #region usings
    using Microsoft.AspNetCore.Mvc;
    using PagedList;
    using BusinessCore.Abstract;
    using Data.Db;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using WebApplication.Models;
    using Data.Models.DTOs;
    using Data.Models;
    using System.Linq;
    using System.Dynamic;
    #endregion
    public class ThesesController : Controller
    {
        private readonly IThesisService _thesisService;

        private ThesesContext db = new ThesesContext();

        public ThesesController(IThesisService thesisService)
        {
            _thesisService = thesisService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var result = _thesisService.GetAll();
                if (result.IsSuccess)
                {
                    return View(result.Data.ToPagedList(pageNumber: 1, pageSize: 10));
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public IActionResult Detail(int thesisNumber)
        {
            try
            {
                var result = _thesisService.GetByNumber(thesisNumber);
                if (result.IsSuccess)
                {
                    return View(result.Data);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Filter()
        {
            var thesisModel = new ThesisModel();

            List<SelectListItem> universities;
            List<SelectListItem> institutes;
            universities = db.UNIVERSITIES.ToList().Select(i => new SelectListItem
            {
                Text = i.NAME.ToString(),
                Value = i.UNIVERSITYID.ToString()

            }).ToList();

            institutes = db.INSTITUTES.ToList().Select(i => new SelectListItem
            {
                Text = i.NAME.ToString(),
                Value = i.INSTITUTEID.ToString()
            }).ToList();

            ViewBag.Universities = universities;
            ViewBag.Institutes = institutes;
            return View(thesisModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(ThesisModel thesisModel)
        {


            var result = _thesisService.GetFilter(thesisModel);

            return View(result);
        }
    }
}
