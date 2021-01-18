using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vechicles.Entities;
using Vechicles.Repositories;
using Vechicles.ViewModels.Cars;

namespace Vechicles.Controllers
{
    public class CarsController : Controller
    {
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            User loggedUser = (User)Session["loggedUser"];

            CarsRepository repo = new CarsRepository();
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

            Car item = new Car();
            item.OwnerId = ((User)Session["loggedUser"]).Id;
            item.Brand = model.Brand;
            item.Color = model.Color;
            item.FullDescription = model.FullDescription;


            CarsRepository repo = new CarsRepository();
            repo.Insert(item);

            return RedirectToAction("Index", "Cars");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            CarsRepository repo = new CarsRepository();
            Car item = repo.GetById(id);

            if (item == null)
                return RedirectToAction("Index", "Cars");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Brand = item.Brand;
            model.Color = item.Color;
            model.FullDescription = item.FullDescription;


            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(model);

            Car item = new Car();
            item.Id = model.Id;
            item.OwnerId = ((User)Session["loggedUser"]).Id;
            item.Brand = model.Brand;
            item.Color = model.Color;
            item.FullDescription = model.FullDescription;


           CarsRepository repo = new CarsRepository();
            repo.Update(item);

            return RedirectToAction("Index", "Cars");
        }

        public ActionResult Delete(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            CarsRepository repo = new CarsRepository();
            repo.Delete(id);

            return RedirectToAction("Index", "Cars");
        }
    }
}