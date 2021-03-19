using Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Factory.Controllers
{
    public class MachinesController : Controller
    {
      private readonly FactoryContext _db;

      public MachinesController(FactoryContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        return View(_db.Machines.ToList());
      }

      public ActionResult Create()
      {
        ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
        return View();
      }

      [HttpPost]
      public ActionResult Create(Machine machine, int EngineerId)
      {
        machine.InstallationDate = DateTime.Now;
        _db.Machines.Add(machine);
        _db.SaveChanges();
        if (EngineerId != 0)
        {
          _db.Repair.Add(new Repair() { EngineerId = EngineerId, MachineId = machine.MachineId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
}