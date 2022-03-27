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
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Type");
      return View();
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
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Type");
      Engineer foundEngineer = _db.Engineers
        .Include(engineer => engineer.JoinEngineerMachine)
        .ThenInclude(joinMachine => joinMachine.Machine)
        .Include(engineer => engineer.JoinEngineerLicense)
        .ThenInclude(joinLicense => joinLicense.License)
        .FirstOrDefault(model => model.EngineerId == id);
      return View(foundEngineer);
    }

    public ActionResult Edit(int id)
    {
      Engineer foundEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(foundEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var foundEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(foundEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var foundEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(foundEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeletePatient(int joinId)
    {
      var joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      int savedEngineer = joinEntry.EngineerId;
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = savedEngineer});
    }

    [HttpPost]
    public ActionResult DeleteLicense(int joinId)
    {
      var joinEntry = _db.EngineerLicenses.FirstOrDefault(entry => entry.EngineerLicenseId == joinId);
      int savedEngineer = joinEntry.EngineerId;
      _db.EngineerLicenses.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = savedEngineer});
    }
  }
}