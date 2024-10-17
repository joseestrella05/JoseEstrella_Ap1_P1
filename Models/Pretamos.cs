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
    public string Concepto { get; set; } = null!;
    public double Balance { get; set; }
    [Required(ErrorMessage = " Campo obligatorio")]
    [Range(1, double.MaxValue)]
    public double Monto { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un deudor válido")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    [InverseProperty("Prestamos")]
    public virtual Deudores Deudor { get; set; } = null!;
}