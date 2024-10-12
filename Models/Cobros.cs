using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseEstrella_Ap1_P1.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        [Required(ErrorMessage = "fecha obligatoria")]
        public DateTime Fecha {  get; set; }
        [ForeignKey("Deudores")]
        [Required(ErrorMessage = "Selecionar un Deudor")]
        public int DeudorId { get; set; }

        [ForeignKey("DeudorId")]
        public Deudores Deudores { get; set; }

        [ForeignKey("Prestamos")]
        public int PrestamoId {  get; set; }

        [ForeignKey("PrestamoId")]
        public Pretamos pretamos { get; set; }
       
        [ForeignKey("CobroId")]
        public ICollection<CobrosDetalle> CobrosDetalles { get; set; } = new List<CobrosDetalle>();


    }
}
