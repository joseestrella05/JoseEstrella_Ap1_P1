using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseEstrella_Ap1_P1.Models;

	public class CobrosDetalles
	{
		[Key]
		public int DetallId { get; set; }
		[Required(ErrorMessage = " Campo obligatorio")]
		public int CobroId { get; set; }
		[Required(ErrorMessage = " Campo obligatorio")]
		public int PrestamoId { get; set; }
		[Required(ErrorMessage = " Campo obligatorio")]
		[Range(1, double.MaxValue, ErrorMessage = "Debe agregar un valor cobrado")]
		public double? ValorCobrado { get; set; }
	}
