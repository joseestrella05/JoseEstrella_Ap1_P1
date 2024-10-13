using JoseEstrella_Ap1_P1.DAL;
using JoseEstrella_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JoseEstrella_Ap1_P1.Services;

    public class DeudorServices(Contexto contexto)
    {
        private readonly Contexto _contexto = contexto;

        public async Task<List<Deudores>> Listar(Expression<Func<Deudores, bool>> criterio)
        {
            return await _contexto.Deudores
                .AsNoTracking().Where(criterio)
                .ToListAsync();
        }
    }
