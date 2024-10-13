using System.ComponentModel.DataAnnotations;
namespace JoseEstrella_Ap1_P1.Models;

public class Deudores
{
    [Key]
    [Required]
    public int DeudoresId { get; set; }

    [Required(ErrorMessage = " Campo obligatorio")]
    public string? Nombres { get; set; }

}

