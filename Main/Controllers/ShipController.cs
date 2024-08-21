using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class ShipController : Controller
    {
        public IActionResult Index()
        {
            return View("IndexShip");
        }

        public IActionResult Detail(int id)
        {
            ViewBag.DetailId = id;
            return View("DetailShip");
        }

        public IActionResult Add()
        {
            return View("AddShip");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.EditId = id;
            return View("EditShip");
        }

        public IActionResult Delete()
        {
            return View("IndexShip");
        }
    }
}
