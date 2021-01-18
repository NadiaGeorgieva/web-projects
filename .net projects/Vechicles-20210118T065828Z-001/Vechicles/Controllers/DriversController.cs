using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vechicles.Entities;
using Vechicles.Repositories;
using Vechicles.ViewModels.Drivers;

namespace Vechicles.Controllers
{
    public class DriversController : Controller
    {
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            User loggedUser = (User)Session["loggedUser"];

            DriversRepository repo = new DriversRepository();
            ViewData["items"] = repo.GetAll(i => i.OwnerId == loggedUser.Id);



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

            Driver item = new Driver();
            item.OwnerId = ((User)Session["loggedUser"]).Id;
            item.Name = model.Name;
            item.Age = model.Age;
            item.DrivingLicence = model.DrivingLicence;


            DriversRepository repo = new DriversRepository();
            repo.Insert(item);

            return RedirectToAction("Index", "Drivers");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            DriversRepository repo = new DriversRepository();
            Driver item = repo.GetById(id);

            if (item == null)
                return RedirectToAction("Index", "Drivers");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Name = item.Name;
            model.Age = item.Age;
            model.DrivingLicence = item.DrivingLicence;


            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(model);

            Driver item = new Driver();
            item.Id = model.Id;
            item.OwnerId = ((User)Session["loggedUser"]).Id;
            item.Name = model.Name;
            item.Age = model.Age;
            item.DrivingLicence = model.DrivingLicence;


            DriversRepository repo = new DriversRepository();
            repo.Update(item);

            return RedirectToAction("Index", "Drivers");
        }

        public ActionResult Delete(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            DriversRepository repo = new DriversRepository();
            repo.Delete(id);

            return RedirectToAction("Index", "Drivers");
        }
    }
}