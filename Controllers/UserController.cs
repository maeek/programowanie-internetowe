using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rejestr_osob_zaginionych.Models;

namespace rejestr_osob_zaginionych.Controllers
{
  public class UserController : Controller
  {
    private readonly IAuthService _authService;

    public UserController(IAuthService authService)
    {
      _authService = authService;
    }

    public IActionResult Create()
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        return View();
      }

      return RedirectToAction("Index", "Person");
    }

    [HttpPost]
    public IActionResult CreateAction()
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        _authService.Register(Request.Form["Username"], Request.Form["Password"], int.Parse(Request.Form["Role"]));
        return RedirectToAction("Index");
      }

      return RedirectToAction("Index", "Person");
    }

    public IActionResult Edit(int id) {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        var user = _authService.GetUser(id);
        return View(user);
      }

      return RedirectToAction("Index", "Person");
    }

    [HttpPost]
    public IActionResult Edit(UserModel user)
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        _authService.UpdateUser(user);
        return RedirectToAction("Index");
      }

      return RedirectToAction("Index", "Person");
    }

    public IActionResult Delete(int id)
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        var user = _authService.GetUser(id);
        return View(user);
      }
      
      return RedirectToAction("Index", "Person");
    }

    public IActionResult Delete(UserModel user)
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        _authService.DeleteUser(user.ID);
        return RedirectToAction("Index");
      }
     
      return RedirectToAction("Index", "Person");
    }

    public IActionResult Index()
    {
      if (Request.Cookies.ContainsKey("UserRole") && Request.Cookies["UserRole"] == "1")
      {
        return View(_authService.GetUsers());
      }

      return RedirectToAction("Index", "Person");
    }
  }
}
