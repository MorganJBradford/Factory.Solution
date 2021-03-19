using Microsoft.AspNetCore.Mvc;

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
    }
}