using Microsoft.EntityFrameworkCore;
using JoseEstrella_Ap1_P1.DAL;
using JoseEstrella_Ap1_P1.Models;
using System.Linq.Expressions;

namespace JoseEstrella_Ap1_P1.Services;

public class CobroServices(Contexto contexto)
{
	private async Task<bool> Existe(int cobroId)
	{
		return await contexto.Cobros.AnyAsync(c => c.CobroId == cobroId);
	}

	private async Task<bool> Insertar(Cobros cobro)
	{
		contexto.Cobros.Add(cobro);
		await AfectarPrestamos(cobro.CobrosDetalles.ToArray(), TipoOperacion.Resta);
		return await contexto.SaveChangesAsync() > 0;
	}

	private async Task AfectarPrestamos(CobrosDetalles[] detalle, TipoOperacion tipoOperacion)
	{
		foreach (var item in detalle)
		{
			var prestamo = await contexto.Prestamos.SingleAsync(p => p.PrestamoId == item.PrestamoId);
			if (tipoOperacion == TipoOperacion.Resta)
				prestamo.Balance -= item.ValorCobrado;
			else
				prestamo.Balance += item.ValorCobrado;

		}
	}

	private async Task<bool> Modificar(Cobros cobro)
	{
		contexto.Update(cobro);
		return await contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Guardar(Cobros cobro)
	{
		if (!await Existe(cobro.CobroId))
		{
			return await Insertar(cobro);
		}
		else
		{
			return await Modificar(cobro);
		}
	}

	public async Task<Cobros> Buscar(int cobroId)
	{
		return await contexto.Cobros.Include(d => d.Deudor)
			.Include(d => d.CobrosDetalles)
			.FirstOrDefaultAsync(c => c.CobroId == cobroId);
	}

	public async Task<bool> Eliminar(int cobroId)
	{
		var cobro = contexto.Cobros.Find(cobroId);

		await AfectarPrestamos(cobro.CobrosDetalles.ToArray(), TipoOperacion.Suma);

		contexto.CobrosDetalles.RemoveRange(cobro.CobrosDetalles);
		contexto.Cobros.Remove(cobro);
		var cantidad = await contexto.SaveChangesAsync();
		return cantidad > 0;
	}

	public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
	{
		return await contexto.Cobros.Include(d => d.Deudor)
			.Include(d => d.CobrosDetalles)
			.Where(criterio)
			.AsNoTracking()
			.ToListAsync();
	}


}

public enum TipoOperacion
{
	Suma = 1,
	Resta = 2
}
