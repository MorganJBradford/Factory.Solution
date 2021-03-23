using Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public ViewResult Index(string sortOrder, string searchString)
    {
      ViewBag.MakeSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      var machines = from m in _db.Machines
        select m;
      if (!String.IsNullOrEmpty(searchString))
      {
        machines = machines.Where(m => m.Name.Contains(searchString));
      }
      machines = machines.OrderBy(m => m.Name);
      return View(machines.ToList());
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

    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
        .Include(machine => machine.JoinEntities)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine, int EngineerId, DateTime InstallationDate)
    {
      machine.InstallationDate = InstallationDate;
      bool duplicate = _db.Repair.Any(x => x.EngineerId == EngineerId && x.MachineId == machine.MachineId);
      if (EngineerId != 0 && !duplicate)
      {
        _db.Repair.Add(new Repair { EngineerId = EngineerId, MachineId = machine.MachineId });
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
      bool duplicate = _db.Repair.Any(x => x.EngineerId == EngineerId && x.MachineId == machine.MachineId);
      if (EngineerId != 0 && !duplicate)
      {
        _db.Repair.Add(new Repair() { EngineerId = EngineerId, MachineId = machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [HttpPost]
    public ActionResult DeleteEngineer(int joinId)
    {
      var joinEntry = _db.Repair.FirstOrDefault(entry => entry.RepairId == joinId);
      _db.Repair.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}