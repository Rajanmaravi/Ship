using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Entities.Models
{
    [Table("Ship")]
    public class Ship
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Port is required")]
        public string? Port { get; set; }
        public string? Destination { get; set; }
        public int? Capacity { get; set; }
        public DateTime? ETD { get; set; }
        public DateTime? ETA { get; set; }
        public virtual ICollection<Cargo>? Cargos { get; set; }
    }
}
