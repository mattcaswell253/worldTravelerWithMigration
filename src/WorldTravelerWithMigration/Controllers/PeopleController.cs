using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldTravelerWithMigration.Models;


namespace WorldTravelerWithMigration.Controllers
{
    public class PeopleController : Controller
    {
        private WorldTravelerDbContext db = new WorldTravelerDbContext();
        public IActionResult Index()
        {
            return View(db.Peoples.Include(Peoples => Peoples.Experience).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(Peoples => Peoples.PeopleId == id);
            return View(thisPeople);
        }
        public IActionResult Create()
        {
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Description");
            return View();
        }
        [HttpPost]
        public IActionResult Create(People People)
        {
            db.Peoples.Add(People);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(peoples => peoples.PeopleId == id);
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Description");
            return View(thisPeople);
        }
        [HttpPost]
        public IActionResult Edit(People people)
        {
            db.Entry(people).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(Peoples => Peoples.PeopleId == id);
            return View(thisPeople);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(Peoples => Peoples.PeopleId == id);
            db.Peoples.Remove(thisPeople);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
