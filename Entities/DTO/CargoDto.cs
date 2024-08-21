using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class CargoDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string? Type { get; set; }
        public string? Item { get; set; }
    }

    public class CargoCreateDto
    {
        [Required(ErrorMessage = "Count is required")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "ShipId is required")]
        public int ShipId { get; set; }

        [Required(ErrorMessage = "Item is required")]
        public string? Item { get; set; }
    }

    public class CargoUpdateDto
    {
        [Required(ErrorMessage = "Count is required")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Item is required")]
        public string? Item { get; set; }
    }
}
