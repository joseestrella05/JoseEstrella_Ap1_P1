using System.ComponentModel.DataAnnotations;

namespace JoseEstrella_Ap1_P1.Models;

public class Pretamos
{
    [Key]
    public int Id { get; set; }
   
    [Required(ErrorMessage = "el campo deudor es obligatiorio")]
    public string Deudor { get; set; }

    [Required(ErrorMessage = "campo obligatotio")]
    public string Concepto { get; set; }

    [Required(ErrorMessage = "El monto es obligatorio")]
    public int Monto { get; set; }

}
