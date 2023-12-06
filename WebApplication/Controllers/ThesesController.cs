using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Db;
using Data.Models;
using PagedList;
using PagedList.Mvc;
namespace WebApplication.Controllers
{
    public class ThesesController : Controller
    {
        private readonly ThesesContext _context;

        public ThesesController(ThesesContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int pageNumber= 1)
        {

        }

        // GET: Theses
        
    }
}
