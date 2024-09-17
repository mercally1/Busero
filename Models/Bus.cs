using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busero.Models;

public class Bus
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Placa { get; set; }

    [Required]
    [MaxLength(5)]
    [Display (Name = "Año")]
    public string? Anho { get; set; }

    [Required]
    [MaxLength(35)]
    [Display (Name = "Marca")]
    public string? Brand { get; set; }

    [Required]
    [MaxLength(25)]
    [Display (Name = "Modelo")]
    public string? Model { get; set; }

    [Required]
    [Display (Name = "Conductor")]
    public int? DriverId { get; set; }

    [ForeignKey("DriverId")]
    public virtual Driver? Driver { get; set; }
}
