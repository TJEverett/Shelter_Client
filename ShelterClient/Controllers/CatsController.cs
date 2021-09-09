using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShelterClient.Models;

namespace ShelterClient.Controllers
{
  public class CatsController : Controller
  {
    [HttpGet("/cats")]
    public ActionResult Index()
    {
      ViewBag.gender = new SelectList(
        new List<SelectListItem>
        {
          new SelectListItem { Selected = true, Text = "All", Value = "both"},
          new SelectListItem { Selected = false, Text = "Females only", Value = "female"},
          new SelectListItem { Selected = false, Text = "Males only", Value = "male"}
        }, "Value", "Text", 1);

      ViewBag.isKitten = new SelectList(
        new List<SelectListItem>
        {
          new SelectListItem { Selected = true, Text = "All", Value = "both"},
          new SelectListItem { Selected = false, Text = "Kittens only", Value = "true"},
          new SelectListItem { Selected = false, Text = "Adults only", Value = "false"}
        }, "Value", "Text", 1);

      return View(Cat.GetCats("both", "both"));
    }

    [HttpPost]
    public ActionResult Index(string gender, string isKitten)
    {
      ViewBag.gender = new SelectList(
        new List<SelectListItem>
        {
          new SelectListItem { Selected = true, Text = "All", Value = "both"},
          new SelectListItem { Selected = false, Text = "Females only", Value = "female"},
          new SelectListItem { Selected = false, Text = "Males only", Value = "male"}
        }, "Value", "Text", 1);

      ViewBag.isKitten = new SelectList(
        new List<SelectListItem>
        {
          new SelectListItem { Selected = true, Text = "All", Value = "both"},
          new SelectListItem { Selected = false, Text = "Kittens only", Value = "true"},
          new SelectListItem { Selected = false, Text = "Adults only", Value = "false"}
        }, "Value", "Text", 1);

      return View(Cat.GetCats(gender, isKitten));
    }

    public ActionResult Details(int id)
    {
      return View(Cat.GetDetails(id));
    }
  }
}