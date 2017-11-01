using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weddingPlanner.Models;

namespace weddingPlanner.Controllers
{
    public class UserController : Controller
    {
        private weddingPlannerContext _context;
        public UserController(weddingPlannerContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            logRegCompositeModel compositeModel = new logRegCompositeModel();
            return View(compositeModel);
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(logRegCompositeModel incoming)
        {
            RegistrationViewModel registrationData = incoming.registration;
            TryValidateModel(registrationData);
            if (ModelState.IsValid)
            {
                newUser = new Users();
                System.Console.WriteLine("registration validates");
            } else {
                System.Console.WriteLine("no validation here");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(logRegCompositeModel incoming)
        {
            loginViewModel loginData = incoming.login;
            TryValidateModel(loginData);
            if (ModelState.IsValid)
            {
                System.Console.WriteLine("Login validates");
            } else {
                System.Console.WriteLine("login broke");
            }
            return RedirectToAction("Index");
        }
    }
}
