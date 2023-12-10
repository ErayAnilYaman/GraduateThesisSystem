
namespace WebApplication.Controllers
{
    #region usings


    using Microsoft.AspNetCore.Mvc;

    using PagedList;
    using PagedList.Mvc;
    using BusinessCore.Abstract;
    using Data.Db;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Data.Models;
    using NuGet.Protocol;
    using WebApplication.Models;
    using Data.Models.DTOs;
    #endregion
    public class ThesesController : Controller
    {
        private readonly IThesisService _thesisService;

        private  ThesesContext db = new ThesesContext();
        public ThesesController(IThesisService thesisService)
        {
            _thesisService = thesisService;
        }
        [HttpGet("Index")]
        public IActionResult Index()
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

                return BadRequest(ex);
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

                return BadRequest(ex);
            }
        }
        [HttpGet]
        public IActionResult Filter()
        {
            ThesisModel model = 
            List<SelectListItem> universities;
            universities = (from i in db.UNIVERSITIES.ToList() select new SelectListItem
            {
                Text = i.ID.ToString(),
                Value = i.UNIVERSITYNAME.ToString()
            }).ToList();
            ViewData["Universities"] = universities;

            List<SelectListItem> institutes;
            institutes = (from i in db.INSTITUTES.ToList()
                            select new SelectListItem
                            {
                                Text = i.INSTITUTEID.ToString(),
                                Value = i.INSTITUTENAME.ToString()
                            }).ToList();

            ViewData["Universities"] = universities;
            ViewData["Institutes"] = institutes;

            return View(model);
        }
        [HttpPost]
        public IActionResult Filter(Thesis thesis)
        {

            ViewData["Title"] = 
            return RedirectToAction("Index");
        }
    }
}
