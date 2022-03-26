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
  }   
}   