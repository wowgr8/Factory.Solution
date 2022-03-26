using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineer.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Type");
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, int MachineId, int LicenseId)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      if (MachineId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() {MachineId = MachineId, EngineerId = engineer.EngineerId});
        _db.SaveChanges();
      }
      if (LicenseId != 0)
      {
        _db.EngineerLicenses.Add(new EngineerLicense() {LicenseId = LicenseId, EngineerId = engineer.EngineerId});
        _db.SaveChanges();
      }
    }
  }
}