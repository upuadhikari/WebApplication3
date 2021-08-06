using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
            public readonly ApplicationDbContext _db;
            public UserController(ApplicationDbContext db)
            {
                _db = db;
            }
            public IActionResult Index()
            {
            
                List<User> user = new List<User>();

                var user_list = _db.users.ToList();

                return View(user_list);
            }

        [HttpGet]
        public IActionResult Create()
        {
            User usr = new User();
            return View(usr);
        }

        [HttpPost]
        public IActionResult Create(User usr)
        {

            if(usr == null)
        {
            return NotFound();
        }
            if (ModelState.IsValid)
            {
                _db.users.Add(usr);
                _db.SaveChanges();
            }
            else
            {
                
                   // ModelState.AddModelError("", "Fields cannot be empty");
                    return View();
            }

        return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {

            User usr = _db.users.Find(id);
            if (usr == null)
            {
                return NotFound();
            }

            return View("Edit",usr);
        }

        [HttpPost]
        public IActionResult Edit(User usr)
        {

            if (usr == null)
            {
                return NotFound();
            }

            _db.users.Update(usr);
            _db.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            User usr = _db.users.Find(id);
            if (usr == null)
            {
                return NotFound();
            }

            _db.users.Remove(usr);
            _db.SaveChanges();

            return RedirectToAction("index");
        }



    }
}
