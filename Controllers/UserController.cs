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
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(logRegCompositeModel incoming)
        {
            RegistrationViewModel registrationData = incoming.registration;
            TryValidateModel(registrationData);
            if (ModelState.IsValid)
            {
                Users newUser = new Users();
                PasswordHasher<Users> hasher = new PasswordHasher<Users>();
                newUser.firstName = registrationData.firstName;
                newUser.lastName = registrationData.lastName;
                newUser.email = registrationData.email;
                newUser.password = hasher.HashPassword(newUser, registrationData.password);
                _context.users.Add(newUser);
                _context.SaveChanges();
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
                Users user = _context.users.FirstOrDefault(entry => entry.email == loginData.email);
                if (user != null)
                {
                    PasswordHasher<Users> hasher = new PasswordHasher<Users>();
                    if (hasher.VerifyHashedPassword(user, user.password, loginData.password) != 0)
                    {
                        HttpContext.Session.SetInt32("currentUserId", user.usersId);
                        return RedirectToAction("list", "Wedding");
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
