using JoseEstrella_Ap1_P1.DAL;
using JoseEstrella_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JoseEstrella_Ap1_P1.Services;

public class Servicio{
    private readonly Contexto _context;

    public Servicio(Contexto context) => _context = context;

    public async Task<bool> Guardar(Pretamos pretamos)
    {
        if (!await Existe(pretamos.Id))
            return await Insertar(pretamos);
        else
            return await Modificar(pretamos);
    }

    public async Task<bool> Insertar(Pretamos pretamos)
    {
        _context.pretamos.Add(pretamos);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Pretamos pretamos)
    {
        _context.pretamos.Update(pretamos);
        return await _context.SaveChangesAsync() > 0;
    } 
    

    public async Task<bool> Existe(int id)
    {
        return await _context.pretamos
            .AnyAsync(p => p.Id == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var pretamo = await _context.pretamos
                .Where(t=> t.Id == id)
                .ExecuteDeleteAsync();
        return pretamo > 0;
    }

    public async Task<Pretamos?> Buscar(int id)
    {
        return await _context.pretamos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Pretamos?> BuscarNombre(string Deudor)
    {
        return await _context.pretamos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Deudor == Deudor);
    }

    public async Task<List<Pretamos>> Listar(Expression<Func<Pretamos, bool>> criterio)
    {
        return await _context.pretamos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

}
