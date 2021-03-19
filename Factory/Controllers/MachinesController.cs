using Factory.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}