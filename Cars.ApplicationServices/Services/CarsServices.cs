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
            Car newCar = CreateCarFromDto(dto);
            newCar.ModifiedAt = DateTime.Now;
            newCar.CreatedAt = DateTime.Now;

            await _context.CarsDB.AddAsync(newCar);
            await _context.SaveChangesAsync();
            return newCar;
        }

      

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.CarsDB.FirstOrDefaultAsync (x => x.Id == id);

            return result;
        }

        public async Task<Car> Delete(Guid id)
        {
            var carToDelete = await _context.CarsDB.FirstOrDefaultAsync(x => x.Id == id);
            if (carToDelete != null)
            {
                _context.CarsDB.Remove(carToDelete);
                await _context.SaveChangesAsync();
            }
            return carToDelete;
        }

        public async Task<Car> Update(CarsDto dto)
        {
            Car newCar = CreateCarFromDto(dto);
            newCar.ModifiedAt = DateTime.Now;

            _context.CarsDB.Update(newCar);
            await _context.SaveChangesAsync();
            return newCar;
        }




        private static Car CreateCarFromDto(CarsDto dto)
        {
            Car newCar = new Car();
            newCar.Id = dto.Id;
            newCar.Make = dto.Make;
            newCar.Model = dto.Model;
            newCar.Color = dto.Color;
            newCar.Doors = dto.Doors;
            newCar.FuelType = dto.FuelType;
            newCar.CreatedAt = dto.CreatedAt;

            return newCar;
        }
    }
}
