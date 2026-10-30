using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagementSystem.Models;

public class Car
{
    public int Id { get; set; }

    [Required, StringLength(60)]
    public string Make { get; set; } = string.Empty;

    [Required, StringLength(60)]
    public string Model { get; set; } = string.Empty;

    [Range(1886, 2100)]
    public int Year { get; set; } = DateTime.UtcNow.Year;

    [Column(TypeName = "decimal(18, 2)"), Range(0, 100000000)]
    public decimal Price { get; set; }

    [Range(0, 2000000)]
    public int Mileage { get; set; }

    [StringLength(30)]
    public string Color { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Notes { get; set; }

    public DateTime AddedOn { get; set; } = DateTime.UtcNow;
}
