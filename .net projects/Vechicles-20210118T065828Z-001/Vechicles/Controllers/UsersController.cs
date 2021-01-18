using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vechicles.Entities;
using Vechicles.Repositories;
using Vechicles.ViewModels.Users;

namespace Vechicles.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UsersRepository repo = new UsersRepository();
            ViewData["items"] = repo.GetAll();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateVM model)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            UsersRepository repo = new UsersRepository();
            repo.Insert(item);

            return RedirectToAction("Index", "Users");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UsersRepository repo = new UsersRepository();
            User item = repo.GetById(id);

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Username = item.Username;
            model.Password = item.Password;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Id = model.Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            UsersRepository repo = new UsersRepository();
            repo.Update(item);

            return RedirectToAction("Index", "Users");
        }

        public ActionResult Delete(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            UsersRepository repo = new UsersRepository();
            repo.Delete(id);

            return RedirectToAction("Index", "Users");
        }
    }
}