using System.ComponentModel.DataAnnotations;

namespace JoseEstrella_Ap1_P1.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [Required (ErrorMessage = "campo obligatorio")]
        public int ValorCobrado { get; set; }
        public  int CobroId { get; set; }
        
        public int PrestamoId { get; set; }



    }
}
