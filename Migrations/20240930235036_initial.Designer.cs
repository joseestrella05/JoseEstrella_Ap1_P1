﻿// <auto-generated />
using JoseEstrella_Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JoseEstrella_Ap1_P1.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240930235036_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("JoseEstrella_Ap1_P1.Models.Pretamos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Deudor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Monto")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("pretamos");
                });
#pragma warning restore 612, 618
        }
    }
}
