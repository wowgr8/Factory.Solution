using Factory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class LicensesController : Controller
  {
    private readonly FactoryContext _db;

    public LicensesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Licenses.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(License license, int EngineerId)
    {
      _db.Licenses.Add(license);
      _db.SaveChanges();
      if (EngineerId != 0)
      {
        _db.EngineerLicenses.Add(new EngineerLicense() {EngineerId = EngineerId, LicenseId = license.LicenseId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      License foundLicense = _db.Licenses
        .Include(license => license.JoinEngineerLicense)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(model => model.LicenseId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(foundLicense);
    }

    public ActionResult Edit(int id)
    {
      var foundLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(foundLicense);
    }

    [HttpPost]
    public ActionResult Edit(License license, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerLicenses.Add(new EngineerLicense() {EngineerId = EngineerId, LicenseId = license.LicenseId});
      }
      _db.Entry(license).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      License foundLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      return View(foundLicense);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      License foundLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      _db.Licenses.Remove(foundLicense);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      License foundLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(foundLicense);
    }

    [HttpPost]
    public ActionResult AddEngineer(License license, int EngineerId)
    {
      if (EngineerId !=0)
      {
        _db.EngineerLicenses.Add(new EngineerLicense() {EngineerId = EngineerId, LicenseId = license.LicenseId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = license.LicenseId});
    }

    [HttpPost]
    public ActionResult DeleteEngineer(int joinId)
    {
      var joinEntry = _db.EngineerLicenses.FirstOrDefault(entry => entry.EngineerLicenseId == joinId);
      int savedLicense = joinEntry.LicenseId;
      _db.EngineerLicenses.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = savedLicense});
    }
  }
}  
