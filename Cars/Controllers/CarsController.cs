using Cars.Data;
using Cars.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using Cars.Core;
using Cars.Core.Dto;
using Cars.Core.ServiceInterface;

namespace Cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsContext _context;
        private readonly ICarServices _carServices;
        public CarsController(CarsContext context,
            ICarServices carServices)
        {
            _context = context;
            _carServices = carServices;

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

        [HttpGet]
        public IActionResult Create()
        {
            CarsCreateViewModel result = new();
            return View("CreateUpdate", result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CarsCreateViewModel vm)
        {
            var dto = new CarsDto()
            {
                Id = vm.Id,
                Make = vm.Make,
                Model = vm.Model,
                Color = vm.Color,
                Doors = vm.Doors,
                FuelType = vm.FuelType,
                CreatedAt = vm.CreatedAt,

            };

            var result = await _carServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));

        }
    }
    }
