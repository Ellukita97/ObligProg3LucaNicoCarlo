﻿// <auto-generated />
using System;
using BlazorApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    [DbContext(typeof(DbContextBlazor))]
    [Migration("20230711194439_DatabaseBlazorImagen")]
    partial class DatabaseBlazorImagen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorApp1.Shared.BoletoCompra", b =>
                {
                    b.Property<int>("IdBoleto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBoleto"));

                    b.Property<int>("Asiento")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("IdBoleto");

                    b.HasIndex("UsuarioId");

                    b.ToTable("BoletosCompras");
                });

            modelBuilder.Entity("BlazorApp1.Shared.Genero", b =>
                {
                    b.Property<int>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGenero"));

                    b.Property<string>("DescGenero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGenero");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("BlazorApp1.Shared.Pelicula", b =>
                {
                    b.Property<int>("IdPelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPelicula"));

                    b.Property<float>("Clasificacion")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeliculaUrlImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinopsis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPelicula");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("BlazorApp1.Shared.Proyeccion", b =>
                {
                    b.Property<int>("ProyeccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProyeccionId"));

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaIdPelicula")
                        .HasColumnType("int");

                    b.Property<int>("SalaIdSala")
                        .HasColumnType("int");

                    b.HasKey("ProyeccionId");

                    b.HasIndex("PeliculaIdPelicula");

                    b.HasIndex("SalaIdSala");

                    b.ToTable("Proyecciones");
                });

            modelBuilder.Entity("BlazorApp1.Shared.Sala", b =>
                {
                    b.Property<int>("IdSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSala"));

                    b.Property<int>("CantTotalAsientos")
                        .HasColumnType("int");

                    b.HasKey("IdSala");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("BlazorApp1.Shared.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BlazorApp1.Shared.BoletoCompra", b =>
                {
                    b.HasOne("BlazorApp1.Shared.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("BlazorApp1.Shared.Proyeccion", b =>
                {
                    b.HasOne("BlazorApp1.Shared.Pelicula", "Pelicula")
                        .WithMany()
                        .HasForeignKey("PeliculaIdPelicula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorApp1.Shared.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaIdSala")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");

                    b.Navigation("Sala");
                });
#pragma warning restore 612, 618
        }
    }
}