using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Datos
{
    public partial class ApiComercioContext : DbContext
    {
        public ApiComercioContext()
        {
        }

        public ApiComercioContext(DbContextOptions<ApiComercioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Procentaje> Procentajes { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10A842B931");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Procentaje>(entity =>
            {
                entity.HasKey(e => e.IdProcentaje)
                    .HasName("PK__Procenta__1B887A7F54308C47");

                entity.ToTable("Procentaje");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Procentaje1).HasColumnName("Procentaje");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__0988921058AB7B26");

                entity.ToTable("Producto");

                entity.Property(e => e.CodigoBarra)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioDeVenta).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_IDCATEGOGORIA");

                entity.HasOne(d => d.IdProcentajeNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProcentaje)
                    .HasConstraintName("FK_IDPROCENTAJE");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.ÎdUsuario)
                    .HasName("PK__Usuario__CBDA710AED14361D");

                entity.ToTable("Usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.ÎdVenta)
                    .HasName("PK__Venta__258868A9C3FD68A5");

                entity.HasOne(d => d.ÎdUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ÎdUsuario)
                    .HasConstraintName("FK_IDPRODUCTO");

                entity.HasOne(d => d.ÎdUsuario1)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ÎdUsuario)
                    .HasConstraintName("FK_IDUSUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
