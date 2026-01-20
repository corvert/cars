using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Core.Domain;
using Cars.Core.Dto;
using Cars.Core.ServiceInterface;
using Cars.Data;
using Microsoft.EntityFrameworkCore;

namespace Cars.ApplicationServices.Services
{
    public class CarsServices : ICarServices
    {
        private readonly CarsContext _context;
        public CarsServices(CarsContext context)
        {
            _context = context;
        }

        public async Task<Car> Create (CarsDto dto)
        {
            Car newCar = new Car();
            newCar.Id = Guid.NewGuid();
            newCar.Make = dto.Make;
            newCar.Model = dto.Model;
            newCar.Color = dto.Color;
            newCar.Doors = dto.Doors;
            newCar.FuelType = dto.FuelType;
            newCar.CreatedAt = DateTime.UtcNow;

            await _context.CarsDB.AddAsync(newCar);
            await _context.SaveChangesAsync();
            return newCar;
        }

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.CarsDB.FirstOrDefaultAsync (x => x.Id == id);

            return result;
        }
    }
}
