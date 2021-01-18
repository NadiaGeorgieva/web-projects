using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vechicles.Entities;
using Vechicles.Repositories;
using Vechicles.ViewModels.Home;

namespace Vechicles.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                UsersRepository repo = new UsersRepository();
                User loggedUser = repo.GetFirstOrDefault(u =>
                                            u.Username == model.Username &&
                                            u.Password == model.Password);

                if (loggedUser == null)
                    ModelState.AddModelError("AuthError", "Invalid username and password!");
                else
                    Session["loggedUser"] = loggedUser;
            }

            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["loggedUser"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}