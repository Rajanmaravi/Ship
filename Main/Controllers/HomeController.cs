using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryWrapper _repository;

        public HomeController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            List<Ship> ship = new List<Ship>();
            ship = _repository.Ship.GetAllShips().ToList();
            return Json(new { data = ship });
        }
    }
}
