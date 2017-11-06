using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            int loggedInUserId = (int)HttpContext.Session.GetInt32("currentUserId");
            Dashboard dashData = new Dashboard
            {
                Weddings = _context.weddings.Include(item => item.guests).ToList(),
                User = _context.users.FirstOrDefault(item => item.usersId ==loggedInUserId)
            };
            return View(dashData);
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(WeddingViewModel incoming)
        {
            if(ModelState.IsValid)
            {
                Weddings newWedding = new Weddings();
                newWedding.newlywedOne = incoming.newlywedOne;
                newWedding.newlywedTwo = incoming.newlywedTwo;
                newWedding.date = incoming.date;
                newWedding.address = incoming.address;
                newWedding.creator = _context.users.FirstOrDefault(
                    user => user.usersId == HttpContext.Session.GetInt32("currentUserId")
                    );
                newWedding.usersId = newWedding.creator.usersId;
                _context.weddings.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("list");
            }
            return RedirectToAction("add");
        }
        [HttpGet]
        [Route("detail/{wedding}")]
        public IActionResult Detail(int wedding)
        {
            List<Weddings> allWeddings = _context.weddings
                .Include(lambdaWedding => lambdaWedding.guests)
                .ThenInclude(guest => guest.user)
                .ToList();
            Weddings chosenWedding = allWeddings.FirstOrDefault(
                thisWedding => thisWedding.weddingsId == wedding
                );
            if (chosenWedding != null)
            {
                ViewBag.thisWedding = chosenWedding;
                return View();
            }
            return RedirectToAction("list");
        }
        [HttpGet]
        [Route("rsvp/{wedding}")]
        public IActionResult Rsvp(int wedding)
        {
            Users currentUser = _context.users.FirstOrDefault(
                user => user.usersId == HttpContext.Session.GetInt32("currentUserId")
                );
            Weddings currentWedding = _context.weddings.FirstOrDefault(item => item.weddingsId == wedding);
            Attending newAttend = new Attending();
            newAttend.usersId = currentUser.usersId;
            newAttend.weddingsId = wedding;
            _context.attending.Add(newAttend);
            _context.SaveChanges();
            currentUser.attending.Add(newAttend);
            currentWedding.guests.Add(newAttend);
            _context.SaveChanges();
            return RedirectToAction("list");
        }
        [HttpGet]
        [Route("unrsvp/{wedding}")]
        public IActionResult UnRsvp(int wedding)
        {
            Weddings thisWedding = _context.weddings.FirstOrDefault(
                item => item.weddingsId == wedding
                );
            Users thisUser = _context.users.FirstOrDefault(
                user => user.usersId == HttpContext.Session.GetInt32("currentUserId")
                    );
            Attending thisAttend = _context.attending
                .SingleOrDefault(
                    item => item.weddingsId == thisWedding.weddingsId 
                    && item.usersId == thisUser.usersId
                    );
            _context.attending.Remove(thisAttend);
            thisWedding.guests.Remove(thisAttend);
            thisUser.attending.Remove(thisAttend);
            _context.SaveChanges();
            return RedirectToAction("list");
        }
    }
}