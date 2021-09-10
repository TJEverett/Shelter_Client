using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShelterClient.Models;

namespace ShelterClient.Controllers
{
  public class DogsController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.gender = new SelectList(
        new List<SelectListItem>
        {
          new SelectListItem { Selected = true, Text = "All", Value = "both"},
          new SelectListItem { Selected = false, Text = "Females only", Value = "female"},
          new SelectListItem { Selected = false, Text = "Males only", Value = "male"}
        }, "Value", "Text", 1);

      ViewBag.isPuppy = new SelectList(
        new List<SelectListItem>
        {
          new SelectListItem { Selected = true, Text = "All", Value = "both"},
          new SelectListItem { Selected = false, Text = "Puppies only", Value = "true"},
          new SelectListItem { Selected = false, Text = "Adults only", Value = "false"}
        }, "Value", "Text", 1);

      return View(Dog.GetDogs("both", "both"));
    }

    [HttpPost]
    public ActionResult Index(string gender, string isPuppy)
    {
      ViewBag.gender = new SelectList(
        new List<SelectListItem>
        {
          new SelectListItem { Selected = true, Text = "All", Value = "both"},
          new SelectListItem { Selected = false, Text = "Females only", Value = "female"},
          new SelectListItem { Selected = false, Text = "Males only", Value = "male"}
        }, "Value", "Text", 1);

      ViewBag.isPuppy = new SelectList(
        new List<SelectListItem>
        {
          new SelectListItem { Selected = true, Text = "All", Value = "both"},
          new SelectListItem { Selected = false, Text = "Puppies only", Value = "true"},
          new SelectListItem { Selected = false, Text = "Adults only", Value = "false"}
        }, "Value", "Text", 1);

      return View(Dog.GetDogs(gender, isPuppy));
    }

    public ActionResult Details(int id)
    {
      return View(Dog.GetDetails(id));
    }

    public ActionResult Create()
    {
      var token = Request.Cookies["sugarCookie"];
      if (token == null)
      {
        return RedirectToAction("Validate", "Login", new { message = 2 });
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> Create(Dog dog)
    {
      var token = Request.Cookies["sugarCookie"];
      if (token == null)
      {
        return RedirectToAction("Validate", "Login", new { message = 2 });
      }
      else
      {
        await Dog.NewDog(dog, token);
        return RedirectToAction("Index");
      }
    }
  }
}