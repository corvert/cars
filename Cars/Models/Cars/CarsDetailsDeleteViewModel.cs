using System.ComponentModel.DataAnnotations;

namespace Cars.Models.Cars
{
    public class CarsDetailsDeleteViewModel
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Doors { get; set; }
        public string FuelType { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm:ss}")]
        public DateTime? ModifiedAt { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm:ss}")]
        public DateTime? CreatedAt { get; set; }
        public bool ShowDeleteBtn { get; set; }
    }
}
