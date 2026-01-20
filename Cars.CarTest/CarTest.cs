using System.Drawing;
using Cars.Core.Dto;
using Cars.Core.ServiceInterface;

namespace Cars.CarTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task Should_AddCar_WhenAllOK()
        {
            //Arrange
            CarsDto car = MockCarDto();
            // Act
            var result = await Svc<ICarServices>().Create(car);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Toyota", result.Make);

        }

       

        [Fact]
        public  async Task ShouldUpdate_AddCar_WhenPartialUpdate()
        {
            //Arrange
            CarsDto car = MockCarDto();
            var createdCar = await Svc<ICarServices>().Create(car);
            car.Model = "Rav";
            // Act & Assert
            var updatedCar = await Svc<ICarServices>().Update(car);

            Assert.Equal("Rav", car.Model);
            Assert.NotEqual(createdCar.Model, updatedCar.Model);

        }

        [Fact]
        public async Task Should_DeleteCarFromDatabase_WhenDelete()
        {
            //Arrange
            CarsDto car = MockCarDto();
            var createdCar = await Svc<ICarServices>().Create(car);
            var deletedCar = await Svc<ICarServices>().Delete(createdCar.Id);
            // Act
            var result = await Svc<ICarServices>().Details(createdCar.Id);

            // Assert
            Assert.Equal(createdCar.Id, deletedCar.Id);
            Assert.Null(result);

        }

        [Fact]
        public async Task Should_RetrunCar_WhenDetailsAsync()
        {
            //Arrange
            CarsDto car = MockCarDto();
            var createdCar = await Svc<ICarServices>().Create(car);
            // Act
            var carDetails = await Svc<ICarServices>().Details(createdCar.Id);
            // Assert
            Assert.NotNull(carDetails);
            Assert.Equal(createdCar.Id, carDetails.Id);
            Assert.Equal("Toyota", carDetails.Make);
        }



        private static CarsDto MockCarDto()
        {
            return new CarsDto
            {
                Make = "Toyota",
                Model = "Corolla",
                Color = "Blue",
                Doors = 3,
                FuelType = "Petrol",

            };
        }
    }
}
