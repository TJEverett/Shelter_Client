using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShelterClient.Models;

namespace ShelterClient.Controllers
{
  public class LoginController : Controller
  {
    [HttpGet("/login/user/{message}")]
    public IActionResult Validate(int message)
    {
      if (message == 1)
      {
        ViewBag.message = "Login Failed";
      }
      else if (message == 2)
      {
        ViewBag.message = "You are not logged in";
      }
      else
      {
        ViewBag.message = "";
      }
      return View();
    }

    [HttpPost("/login/user/{message}")]
    public IActionResult Validate(Login userInfo)
    {
      string token = Login.GetToken(userInfo);

      if(token == null)
      {
        return RedirectToAction("Validate", new {message = 1});
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

    [HttpGet("/login/new")]
    public IActionResult Create()
    {
      var token = Request.Cookies["sugarCookie"];
      if(token == null)
      {
        return RedirectToAction("Validate", new {message = 2});
      }
      else
      {
        return View();
      }
    }

    [HttpPost("/login/new")]
    public async Task<ActionResult> Create(Login userInfo)
    {
      var token = Request.Cookies["sugarCookie"];
      if(token == null)
      {
        return RedirectToAction("Validate", new { message = 2 });
      }
      else
      {
        await Login.Post(userInfo, token);
        return RedirectToAction("Create");
      }
    }

    [HttpGet("/login/delete")]
    public IActionResult Delete()
    {
      var token = Request.Cookies["sugarCookie"];
      if(token == null)
      {
        return RedirectToAction("Validate", new {message = 2});
      }
      else
      {
        return View();
      }
    }

    [HttpPost("/login/delete")]
    public async Task<ActionResult> Delete(Login userInfo)
    {
      var token = Request.Cookies["sugarCookie"];
      if(token == null)
      {
        return RedirectToAction("Validate", new { message = 2 });
      }
      else
      {
        await Login.Delete(userInfo, token);
        return RedirectToAction("Delete");
      }
    }

  }
}