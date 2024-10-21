using JoseEstrella_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace JoseEstrella_Ap1_P1.DAL;

public class Contexto(DbContextOptions<Contexto> options): DbContext(options)
{

    public virtual DbSet<Deudores> Deudores { get; set; }
    public virtual DbSet<Prestamos> Prestamos { get; set; }
    public virtual DbSet<Cobros> Cobros { get; set; }
    public virtual DbSet<CobrosDetalles> CobrosDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deudores>().HasData(
            new List<Deudores>()
            {
                new()
                {
                    DeudorId = 1,
                    Nombres = "Jose Lopez",
                },
                new()
                {
                    DeudorId = 2,
                    Nombres = "Maria Perez",
                }
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}
