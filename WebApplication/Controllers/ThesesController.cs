
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

        private  ThesesContext db = new ThesesContext();
        public ThesesController(IThesisService thesisService)
        {
            _thesisService = thesisService;
        }
        [HttpGet]
        public IActionResult Index(List<Thesis>? theses)
        {
            try
            {
                var result = _thesisService.GetAll();
                if (result.IsSuccess)
                {
                    return View(result.Data.ToPagedList(pageNumber :1 , pageSize :10));
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet]
        public IActionResult Detail(int thesisID)
        {
            try
            {
                var result = _thesisService.GetById(thesisID);
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
            
            IEnumerable<SelectListItem> universities;
            IEnumerable<SelectListItem> institutes;

            universities = (IEnumerable<SelectListItem>)(from i in db.UNIVERSITIES.ToList()
                            select new SelectListItem
                            {
                                Text = i.UNIVERSITYID.ToString(),
                                Value = i.NAME.ToString()
                            });

            institutes = (IEnumerable<SelectListItem>)(from i in db.INSTITUTES.ToList()
                          select new SelectListItem
                          {
                              Text = i.INSTITUTEID.ToString(),
                              Value = i.NAME.ToString()
                          });

            ViewBag.University= universities;
            ViewBag.Institutes= institutes;
            return View(thesisModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(ThesisModel thesisModel)
        {

            if (thesisModel.NUMBER != null)
            {
                return View("Index", db.THESES.FirstOrDefault(T => T.NUMBER == thesisModel.NUMBER));
            }
            var result = _thesisService.GetFilter(thesisModel);

            return View("Index" , result);
        }
        
    }
}
