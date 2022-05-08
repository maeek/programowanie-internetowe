using Microsoft.AspNetCore.Mvc;
using rejestr_osob_zaginionych.Models;
using System.Collections.Generic;

namespace rejestr_osob_zaginionych.Controllers
{
  public class PersonController : Controller
  {
    private readonly IPersonManager _manager;

    public PersonController(IPersonManager manager)
    {
      _manager = manager;
    }

    public IActionResult Details(int id)
    {
      var person = _manager.GetPerson(id);
      return View(person);
    }

    [HttpPost]
    public IActionResult Create(PersonModel personModel)
    {
      if (Request.Cookies.ContainsKey("UserRole") && (Request.Cookies["UserRole"] == "1" || Request.Cookies["UserRole"] == "10"))
      {
        var person = _manager.AddPerson(personModel);
        return RedirectToAction("Details", new { id = person.ID });
      }

      return RedirectToAction("Forbidden");
    }

    [HttpPost]
    public IActionResult Edit(PersonModel personModel)
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        _manager.UpdatePerson(personModel);
        return RedirectToAction("Details", new { id = personModel.ID });
      }

      return RedirectToAction("Forbidden");
    }

    public IActionResult Edit(int id)
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        var person = _manager.GetPerson(id);

        return View(person);
      }

      return RedirectToAction("Forbidden");
    }

    public IActionResult Create()
    {
      if (Request.Cookies.ContainsKey("UserRole") && (Request.Cookies["UserRole"] == "1" || Request.Cookies["UserRole"] == "10"))
      {
        return View();
      }
      return RedirectToAction("Forbidden");
    }

    public IActionResult Index()
    {
      var people = _manager.GetAllPersons();
      return View(people);
    }

    public IActionResult Forbidden()
    {
      return View();
    }

    [HttpGet]
    public IActionResult Gender(string id)
    {
      List<PersonModel> people;
      if (id == "m")
      {
        people = _manager.GetAllMales();
      }
      else if (id == "k")
      {
        people = _manager.GetAllFemales();
      }
      else
      {
        people = _manager.GetAllPersons();
      }

      return View("Index", people);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        var person = _manager.GetPerson(id);
        return View(person);
      }

      return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Delete(PersonModel person)
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        _manager.RemovePerson(person.ID);
      }

      return RedirectToAction("Index");
    }
  }
}
