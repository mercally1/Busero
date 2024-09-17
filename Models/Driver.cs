using System.ComponentModel.DataAnnotations;

namespace Busero.Models;

public class Driver
{
    [Key]
    public int DriverId { get; set; }

    [Required]
    [Display (Name = "Nombre")]
    public string? Name { get; set; }

    [Required]
    [Display (Name = "Apellido")]
    public string? Lastname { get; set; }

    [Required]
    public string? Licencia { get; set; }

    [Required]
    [Display (Name = "Contacto")]
    public string? Contact { get; set; }
}
