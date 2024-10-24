﻿// <auto-generated />
using System;
using JoseEstrella_Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JoseEstrella_Ap1_P1.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.Cobros", b =>
                {
                    b.Property<int>("CobroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CobroId"));

                    b.Property<int>("DeudorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.HasKey("CobroId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.CobrosDetalles", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("CobroId")
                        .HasColumnType("int");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorCobrado")
                        .HasColumnType("float");

                    b.HasKey("DetalleId");

                    b.HasIndex("CobroId");

                    b.ToTable("CobrosDetalles");
                });

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.Deudores", b =>
                {
                    b.Property<int>("DeudorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeudorId"));

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeudorId");

                    b.ToTable("Deudores");

                    b.HasData(
                        new
                        {
                            DeudorId = 1,
                            Nombres = "Jose Lopez"
                        },
                        new
                        {
                            DeudorId = 2,
                            Nombres = "Maria Perez"
                        });
                });

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestamoId"));

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DeudorId")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.HasKey("PrestamoId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.Cobros", b =>
                {
                    b.HasOne("JoseEstrella_Ap1_P1.Models.Deudores", "Deudor")
                        .WithMany("Cobros")
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deudor");
                });

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.CobrosDetalles", b =>
                {
                    b.HasOne("JoseEstrella_Ap1_P1.Models.Cobros", "Cobro")
                        .WithMany("CobrosDetalle")
                        .HasForeignKey("CobroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobro");
                });

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.Prestamos", b =>
                {
                    b.HasOne("JoseEstrella_Ap1_P1.Models.Deudores", "Deudor")
                        .WithMany("Prestamos")
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deudor");
                });

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.Cobros", b =>
                {
                    b.Navigation("CobrosDetalle");
                });

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.Deudores", b =>
                {
                    b.Navigation("Cobros");

                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
