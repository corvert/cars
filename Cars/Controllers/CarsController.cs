using Cars.Models.Cars;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsContext _context;
        public CarsController(CarsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Cars.Select(x => new CarsIndexViewModel
            {
                Id = x.Id,
                Make = x.Make,
                Model = x.Model,
                Color = x.Color,
                Doors = x.Doors,
                FuelType = x.FuelType,
                CreatedAt = x.CreatedAt,
            });
            return View(result);
        }
    }
}
