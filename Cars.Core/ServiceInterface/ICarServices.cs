using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Core.Domain;
using Cars.Core.Dto;

namespace Cars.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Car> Create(CarsDto dto);
        Task<Car> DetailsAsync(Guid id);
        Task<Car> Delete(Guid id);
    }
}
