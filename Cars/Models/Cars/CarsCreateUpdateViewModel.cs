using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Cars.Models.Cars
{
    public class CarsCreateUpdateViewModel
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Make is required")]
        public string Make { get; set; }
 
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        // [Required(ErrorMessage = "Color is required")]
        [AllowNull]
        public string Color { get; set; }
        
        [Required(ErrorMessage = "Number of doors is required")]
        [Range(2, 5, ErrorMessage = "Doors must be between 2 and 5")]
        public int Doors { get; set; }
     
        [Required(ErrorMessage = "Fuel type is required")]
        public string FuelType { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
