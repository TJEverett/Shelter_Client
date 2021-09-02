using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShelterClient.Models;

namespace ShelterClient.Controllers
{
  public class LoginController : Controller
  {
    [HttpGet("/Login")]
    public IActionResult Validate()
    {
      return View();
    }

    [HttpPost("/Login")]
    public IActionResult Validate(Login userInfo)
    {
      string token = Login.GetToken(userInfo);

      if(token == null)
      {
        return RedirectToAction("Validate");
      }
      else
      {
        Response.Cookies.Delete("sugarCookie");
        Response.Cookies.Append(
          "sugarCookie",
          token,
          new CookieOptions()
          {
            Path = "/",
            Expires = DateTime.Now.AddHours(2),
            HttpOnly = false,
            Secure = false
          }
        );
        return RedirectToAction("Index", "Home");
      }
    }
  }
}