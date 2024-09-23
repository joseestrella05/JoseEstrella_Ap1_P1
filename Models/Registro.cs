using System.ComponentModel.DataAnnotations;

namespace JoseEstrella_Ap1_P1.Models;

public class Registro
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }

}
