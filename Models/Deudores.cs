using System.ComponentModel.DataAnnotations;
namespace JoseEstrella_Ap1_P1.Models;

public class Deudores
{
    [Key]
    public int DeudorId {  get; set; }
    [Required(ErrorMessage = "el campo deudor es obligatiorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    public string Nombres {  get; set; }

}
