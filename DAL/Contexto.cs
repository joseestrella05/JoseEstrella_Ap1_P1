using JoseEstrella_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace JoseEstrella_Ap1_P1.DAL;

public class Contexto(DbContextOptions<Contexto> options): DbContext(options)
{

    public DbSet<Prestamos> Prestamos { get; set; }
    public DbSet<Deudores> Deudores { get; set; }
    public DbSet<Cobros> Cobros { get; set; }
    public DbSet<CobrosDetalles> CobrosDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Deudores>().HasData(new List<Deudores>()
        {
            new Deudores() { DeudoresId = 1, Nombres = "Reyphill Nuñez" }

        });
    }
}
