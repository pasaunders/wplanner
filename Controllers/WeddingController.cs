using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using weddingPlanner.Models;

namespace weddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private weddingPlannerContext _context;
        public WeddingController(weddingPlannerContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            ViewBag.weddings = _context.weddings.ToList();
            return View();
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        [Route("detail")]
        public IActionResult Detail()
        {
            return View();
        }
    }
}