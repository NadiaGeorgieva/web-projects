using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vechicles.Entities;
using Vechicles.Repositories;
using Vechicles.ViewModels.Shipments;

namespace Vechicles.Controllers
{
    public class ShipmentsController : Controller
    {
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            User loggedUser = (User)Session["loggedUser"];

            ShipmentsRepository repo = new ShipmentsRepository();
            ViewData["items"] = repo.GetAll(i => i.OwnerId == loggedUser.Id);

            MyDbContext Shared = new MyDbContext();
            List<Shipment> Lists = Shared.Shares
                                                .Where(i => i.UserId == loggedUser.Id)
                                                .Select(i => i.List)
                                                .ToList();
            ViewData["Shared"] = Lists;



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

            Shipment item = new Shipment();
            item.OwnerId = ((User)Session["loggedUser"]).Id;
            item.From = model.From;
            item.Package = model.Package;
            item.Destination = model.Destination;
            item.PriceOfPacket = model.PriceOfPacket;


            ShipmentsRepository repo = new ShipmentsRepository();
            repo.Insert(item);

            return RedirectToAction("Index", "Shipments");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            ShipmentsRepository repo = new ShipmentsRepository();
            Shipment item = repo.GetById(id);

            if (item == null)
                return RedirectToAction("Index", "Shipments");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.From = item.From;
            model.Package = item.Package;
            model.Destination = item.Destination;
            model.PriceOfPacket = item.PriceOfPacket;


            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(model);

            Shipment item = new Shipment();
            item.Id = model.Id;
            item.OwnerId = ((User)Session["loggedUser"]).Id;
            item.From = model.From;
            item.Package = model.Package;
            item.Destination = model.Destination;
            item.PriceOfPacket = model.PriceOfPacket;

            ShipmentsRepository repo = new ShipmentsRepository();
            repo.Update(item);

            return RedirectToAction("Index", "Shipments");
        }

        public ActionResult Delete(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            ShipmentsRepository repo = new ShipmentsRepository();
            repo.Delete(id);

            return RedirectToAction("Index", "Shipments");
        }
        [HttpGet]
        public ActionResult Share(int toDoListId)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            MyDbContext context = new MyDbContext();
            ShipmentsRepository toDoListRepo = new ShipmentsRepository();
            UsersRepository userRepo = new UsersRepository();

            ShareVM model = new ShareVM();
            model.List = toDoListRepo.GetById(toDoListId);
            model.Shares = context.Shares
                                        .Where(i => i.ToDoListId == toDoListId)
                                        .ToList();
            model.Users = userRepo.GetAll();

            return View(model);
        }

        [HttpPost]
        public ActionResult Share(int toDoListId, int userId)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            Share share = new Share();
            share.ToDoListId = toDoListId;
            share.UserId = userId;

            MyDbContext context = new MyDbContext();
            context.Shares.Add(share);
            context.SaveChanges();

            return RedirectToAction("Share", "Shipments", new { toDoListId = toDoListId });
        }
    }
}