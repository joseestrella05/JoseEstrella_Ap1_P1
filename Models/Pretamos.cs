using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseEstrella_Ap1_P1.Models;

public class Prestamos
{
    [Key]
    [Required]
    public int PrestamoId { get; set; }
    [Required(ErrorMessage = " Campo obligatorio")]
    [StringLength(100)]
    [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
    public string? Concepto { get; set; }
    public int Balance { get; set; }
    [Required(ErrorMessage = " Campo obligatorio")]
    [Range(1, double.MaxValue)]
    public int Monto { get; set; }
    [ForeignKey("Deudor")]
    [Required(ErrorMessage = "Debe seleccionar un tipo")]
    public int DeudorId { get; set; }
    public Deudores? Deudor { get; set; }
}