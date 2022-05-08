using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rejestr_osob_zaginionych.Controllers
{
  public class AuthController : Controller
  {
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }


    [HttpPost]
    public IActionResult Login(string Username, string Password)
    {
      var authenticatedUser = _authService.Login(Username, Password);

      if (authenticatedUser != null)
      {
        Response.Cookies.Append("UserID", authenticatedUser.ID.ToString(), new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddDays(1), HttpOnly = true, Secure = true });
        Response.Cookies.Append("UserRole", authenticatedUser.Role.ToString(), new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddDays(1), HttpOnly = true, Secure = true });

        return RedirectToAction("Index", "Person");
      }

      return RedirectToAction("Index", "Auth");
    }

    [HttpDelete]
    public IActionResult Logout()
    {
      Response.Cookies.Delete("UserID");
      Response.Cookies.Delete("UserRole");

      return RedirectToAction("Index", "Auth");
    }

    public IActionResult Index()
    {
      if (Request.Cookies.ContainsKey("UserID"))
      {
        return RedirectToAction("Index", "Person");
      }
      
      return View("Index");
    }
  }

  public interface LoginModel {
    string Username { get; set; }
    string Password { get; set; }

  }
}
