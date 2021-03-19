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
    }
}