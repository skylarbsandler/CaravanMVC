using Microsoft.AspNetCore.Mvc;
using CaravanMVC.Models;
using CaravanMVC.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CaravanMVC.Controllers
{
    public class WagonsController : Controller
    {
        private readonly CaravanMvcContext _context;

        public WagonsController(CaravanMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var wagons = _context.Wagons;
            return View(wagons);
        }

        [Route("/Wagons/{id:int}")]
        public IActionResult Show(int id)
        {
            var wagons = _context.Wagons.Include(e => e.Passengers).Where(e => e.Id == id).Single();
            return View(wagons);
        }
    }
}
