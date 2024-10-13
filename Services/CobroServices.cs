using Microsoft.EntityFrameworkCore;
using JoseEstrella_Ap1_P1.DAL;
using JoseEstrella_Ap1_P1.Models;
using System.Linq.Expressions;

namespace JoseEstrella_Ap1_P1.Services;

public class CobroServices(Contexto contexto)
{
    private readonly Contexto _contexto = contexto;

    public async Task<bool> ExisteId(int id)
    {
        return await _contexto.Cobros.AnyAsync(t => t.CobroId == id);
    }

    private async Task<bool> Insertar(Cobros cobros)
    {
        _contexto.Cobros.Add(cobros);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Cobros cobros)
    {
        _contexto.Update(cobros);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Cobros cobros)
    {
        if (!await ExisteId(cobros.CobroId))
            return await Insertar(cobros);

        return await Modificar(cobros);
    }
    public async Task<bool> Delete(int id)
    {
        return await _contexto.Cobros
            .Where(t => t.CobroId == id).ExecuteDeleteAsync() > 0;
    }
    public async Task<Cobros?> Buscar(int id)
    {
        return await _contexto.Cobros.Include(c => c.CobrosDetalles)
            .FirstOrDefaultAsync(c => c.CobroId == id);
    }

    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        return await _contexto.Cobros.Include(c => c.CobrosDetalles)
            .AsNoTracking().Where(criterio).ToListAsync();
    }
}

