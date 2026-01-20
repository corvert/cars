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
                ModifiedAt = x.ModifiedAt,
                CreatedAt = x.CreatedAt,
            });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarsCreateUpdateViewModel result = new();
            return View("CreateUpdate", result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CarsCreateUpdateViewModel vm)
        {
            CarsDto dto = ConvertFromViewModelToDto(vm);

            var result = await _carServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));

        }

      

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var vm = new CarsDetailsDeleteViewModel
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Color = car.Color,
                Doors = car.Doors,
                FuelType = car.FuelType,
                ModifiedAt = car.ModifiedAt,
                CreatedAt = car.CreatedAt,
               
            };
            vm.ShowDeleteBtn = true;
            return View("DeleteDetails", vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var result = await _carServices.Delete(id);
            if (result == null)
            {

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var vm = new CarsCreateUpdateViewModel();
            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Color = car.Color;
            vm.Doors = car.Doors;
            vm.FuelType = car.FuelType;
            vm.ModifiedAt = DateTime.Now;
            vm.CreatedAt = car.CreatedAt;
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarsCreateUpdateViewModel vm)
        {
            CarsDto dto = ConvertFromViewModelToDto(vm);
            var result = await _carServices.Update(dto);
            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }


        private static CarsDto ConvertFromViewModelToDto(CarsCreateUpdateViewModel vm)
        {
            return new CarsDto()
            {
                Id = vm.Id,
                Make = vm.Make,
                Model = vm.Model,
                Color = vm.Color,
                Doors = vm.Doors,
                FuelType = vm.FuelType,
                ModifiedAt = vm.ModifiedAt,
                CreatedAt = vm.CreatedAt,

            };
        }


    }
}
