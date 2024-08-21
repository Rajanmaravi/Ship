using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Count { get; set; }
        public string? Type { get; set; }

        [Required]
        [ForeignKey(nameof(Ship))]
        public int ShipId { get; set; }
        public Ship? Ship { get; set; }

        public string? Item { get; set; }
    }
}
