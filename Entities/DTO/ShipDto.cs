using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class ShipDto
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public string? Port { get; set; }
        public string? Destination { get; set; }
        public int? Capacity { get; set; }
        public DateTime? ETD { get; set; }
        public DateTime? ETA { get; set; }
        public IEnumerable<CargoDto>? Cargos { get; set; }
    }

    public class ShipCreateDto
    {
        [Required(ErrorMessage = "Company Name is required")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Port is required")]
        public string? Port { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        public string? Destination { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        public int? Capacity { get; set; }

        [Required(ErrorMessage = "ETD is required")]
        public DateTime? ETD { get; set; }

        [Required(ErrorMessage = "ETA is required")]
        public DateTime? ETA { get; set; }
    }

    public class ShipUpdateDto
    {
        [Required(ErrorMessage = "Company Name is required")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Port is required")]
        public string? Port { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        public string? Destination { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        public int? Capacity { get; set; }

        public DateTime? ETD { get; set; }
        public DateTime? ETA { get; set; }
    }
}
