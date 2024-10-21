using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseEstrella_Ap1_P1.Models;

	public class CobrosDetalles
	{
		[Key]
		public int DetalleId { get; set; }
		
		public int CobroId { get; set; }
		
		public int PrestamoId { get; set; }
		
		public double ValorCobrado { get; set; }

		[ForeignKey("CobroId")]
		[InverseProperty("CobrosDetalle")]
		public virtual Cobros Cobro { get; set; } = null!;



    }
