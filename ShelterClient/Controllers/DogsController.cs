using System.Collections.Generic;
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
  }
}