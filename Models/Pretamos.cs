using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseEstrella_Ap1_P1.Models;

public class Pretamos
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "campo obligatotio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    public string Concepto { get; set; }

    [Required(ErrorMessage = "El monto es obligatorio")]
    [Range(0, 200000, ErrorMessage = "Favor de introducir un sueldo mayor que 1 y menor que 200000.")]
    public int Monto { get; set; }

    [Range(0, 200000, ErrorMessage = "Favor de introducir un sueldo mayor que 1 y menor que 200000.")]
    public int Balance {  get; set; }

    [ForeignKey("Deudores")]
    [Required(ErrorMessage = "Selecionar un Deudor")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores Deudores { get; set; }



}
