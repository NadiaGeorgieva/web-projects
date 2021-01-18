using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vechicles.Entities;
using Vechicles.Repositories;
using Vechicles.ViewModels.Recievers;

namespace Vechicles.Controllers
{
    public class RecieversController : Controller
    {
        public ActionResult Index(int toDoListId)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            MyDbContext context = new MyDbContext();

            IndexVM model = new IndexVM();
            model.List = context.Shipments
                                    .Where(i => i.Id == toDoListId)
                                    .FirstOrDefault();
            model.Recievers = context.Recievers
                                    .Where(i => i.OwnerListId == toDoListId)
                                    .ToList();

            return View(model);
        }

        public ActionResult Create(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            CreateVM model = new CreateVM();
            model.OwnerListId = id;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateVM model)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(model);

            Reciever item = new Reciever();
            item.OwnerListId = model.OwnerListId;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;


            MyDbContext context = new MyDbContext();

            context.Recievers.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Recievers", new { toDoListId = model.OwnerListId }
            );
        }

        public ActionResult Edit(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            MyDbContext context = new MyDbContext();
            Reciever item = context.Recievers
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.OwnerListId = item.OwnerListId;
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

            Reciever item = new Reciever();
            item.Id = model.Id;
            item.OwnerListId = model.OwnerListId;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            MyDbContext context = new MyDbContext();

            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index", "Recievers",
                new { toDoListId = model.OwnerListId }
            );
        }

        public ActionResult Delete(int id)
        {
            if (Session["loggedUser"] == null)
                return RedirectToAction("Login", "Home");

            MyDbContext context = new MyDbContext();

            Reciever item = context.Recievers
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault();

            context.Recievers.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Recievers", new { toDoListId = item.OwnerListId });
        }
    }
}