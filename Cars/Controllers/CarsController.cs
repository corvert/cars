using Cars.Data;
using Cars.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using Cars.Core;

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
            var result = _context.CarsDB.Select(x => new CarsIndexViewModel
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
