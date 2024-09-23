using JoseEstrella_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace JoseEstrella_Ap1_P1.DAL;

public class Contexto(DbContextOptions<Contexto> options): DbContext(options)
{

    public DbSet<Registro> Registro { get; set; }
}
