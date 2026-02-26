using System;
using System.Collections.Generic;
using FilmesT.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesT.WebAPI.BdContextFilme;

public partial class FilmeContext : DbContext
{
    public FilmeContext()
    {
    }

    public FilmeContext(DbContextOptions<FilmeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Filme> Filmes { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Filmes;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Filme>(entity =>
        {
            entity.HasKey(e => e.Idfilme).HasName("PK__Filme__4C3389CABCAC9845");

            entity.HasOne(d => d.IdgeneroNavigation).WithMany(p => p.Filmes).HasConstraintName("FK__Filme__IDGenero__5FB337D6");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.Idgenero).HasName("PK__Genero__40E9040FA92B11ED");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuario__52311169D9D769FE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
