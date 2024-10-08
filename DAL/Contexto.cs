using JoseEstrella_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace JoseEstrella_Ap1_P1.DAL;

public class Contexto(DbContextOptions<Contexto> options): DbContext(options)
{

    public DbSet<Pretamos> pretamos { get; set; }
    public DbSet<Deudores> Deudores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Deudores>().HasData(new List<Deudores>(){
            new Deudores() { DeudorId=1, Nombres="Reyphil"}
        });
    }
}
