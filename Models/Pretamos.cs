using System.ComponentModel.DataAnnotations;

namespace JoseEstrella_Ap1_P1.Models;

public class Pretamos
{
    [Key]
    public int Id { get; set; }
   
    [Required(ErrorMessage = "el campo deudor es obligatiorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    public string Deudor { get; set; }

    [Required(ErrorMessage = "campo obligatotio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    public string Concepto { get; set; }

    [Required(ErrorMessage = "El monto es obligatorio")]
    [Range(0, 200000, ErrorMessage = "Favor de introducir un sueldo mayor que 1 y menor que 200000.")]
    public int Monto { get; set; }

    [Required(ErrorMessage = "El monto es obligatorio")]
    [Range(0, 200000, ErrorMessage = "Favor de introducir un sueldo mayor que 1 y menor que 200000.")]
    public int Balance {  get; set; }


}
