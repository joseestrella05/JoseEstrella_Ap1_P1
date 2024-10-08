using JoseEstrella_Ap1_P1.DAL;
using JoseEstrella_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JoseEstrella_Ap1_P1.Services
{
    public class DeudorServices
    {
        private readonly Contexto _context;

        public DeudorServices(Contexto context) => _context = context;

        public async Task<List<Deudores>> Listar(Expression<Func<Deudores, bool>> criterio)
        {
            return await _context.Deudores
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
