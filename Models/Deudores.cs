using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JoseEstrella_Ap1_P1.Models;

public class Deudores
{
    [Key]
 
    public int DeudorId { get; set; }

    public string? Nombres { get; set; }

    [InverseProperty("Deudor")]
    public virtual ICollection<Cobros> Cobros { get; set; } = new List<Cobros>();

    [InverseProperty("Deudor")]
    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();

}

