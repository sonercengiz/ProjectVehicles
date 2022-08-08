using System.ComponentModel.DataAnnotations;

namespace ProjectVehicles.Models
{
    public class Vehicle
    {
        [Key]
        public int ID { get; set; }
        public string Color { get; set; }
    }
}
