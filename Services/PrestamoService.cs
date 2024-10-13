using JoseEstrella_Ap1_P1.DAL;
using JoseEstrella_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JoseEstrella_Ap1_P1.Services;

public class PrestamoService(Contexto contexto)
{
    private readonly Contexto _contexto = contexto;

    public async Task<bool> ExisteId(int id)
    {
        return await _contexto.Prestamos.AnyAsync(t => t.PrestamoId == id);
    }

    private async Task<bool> Insertar(Prestamos prestamos)
    {
        _contexto.Prestamos.Add(prestamos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prestamos cobros)
    {
        _contexto.Update(cobros);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Prestamos prestamos)
    {
        prestamos.Balance = prestamos.Monto;
		if (!await ExisteId(prestamos.DeudorId))
            return await Insertar(prestamos);

        return await Modificar(prestamos);
    }

    public async Task<bool> Delete(int id)
    {
        return await _contexto.Prestamos
            .Where(t => t.DeudorId == id).ExecuteDeleteAsync() > 0;
    }

    public async Task<Prestamos?> Buscar(int id)
    {
        return await _contexto.Prestamos.Include(p => p.Deudor)
            .FirstOrDefaultAsync(p => p.PrestamoId == id);
    }

    public async Task<Prestamos?> GetCliente(int id)
    {
        return await _contexto.Prestamos.Include(p => p.Deudor)
            .FirstOrDefaultAsync(p => p.DeudorId == id);
    }

    public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
    {
        return await _contexto.Prestamos.Include(p => p.Deudor)
            .AsNoTracking().Where(criterio).ToListAsync();
    }
}