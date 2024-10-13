using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseEstrella_Ap1_P1.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, double.MaxValue)]
        public int Monto { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe selecionar un deudor valido")]
        public int DeudorId { get; set; }

        [ForeignKey("CobroId")]
        public ICollection<CobrosDetalles> CobrosDetalles { get; set; } = new List<CobrosDetalles>();


    }
}
