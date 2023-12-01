using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WoofChef.Models;

public partial class ProyectoApicadaContext : DbContext
{
    public ProyectoApicadaContext()
    {
    }

    public ProyectoApicadaContext(DbContextOptions<ProyectoApicadaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbExpediente> TbExpedientes { get; set; }

    public virtual DbSet<TbIngrediente> TbIngredientes { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<TbVenta> TbVentas { get; set; }

    public virtual DbSet<TbVentasProducto> TbVentasProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HAJJ5O1;User Id=sa;Password=12345;Initial Catalog=ProyectoApicada;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbExpediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Exped__3214EC07F9D1D8AF");

            entity.ToTable("tb_Expediente");

            entity.Property(e => e.DescripcionMascota).HasMaxLength(300);
            entity.Property(e => e.EnfermedadesYalergias)
                .HasMaxLength(300)
                .HasColumnName("EnfermedadesYAlergias");
            entity.Property(e => e.NombreDuenno).HasMaxLength(20);
            entity.Property(e => e.NombreMascota).HasMaxLength(20);
        });

        modelBuilder.Entity<TbIngrediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Ingre__3214EC07D734523B");

            entity.ToTable("tb_Ingrediente");

            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Produ__3214EC0739527927");

            entity.ToTable("tb_Producto");

            entity.Property(e => e.Nombre).HasMaxLength(20);
            entity.Property(e => e.Receta).HasMaxLength(500);

            entity.HasMany(d => d.IdIngredientes).WithMany(p => p.IdProductos)
                .UsingEntity<Dictionary<string, object>>(
                    "TbProductoIngrediente",
                    r => r.HasOne<TbIngrediente>().WithMany()
                        .HasForeignKey("IdIngrediente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductoIngrediente_Ingrediente"),
                    l => l.HasOne<TbProducto>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductoIngrediente_Producto"),
                    j =>
                    {
                        j.HasKey("IdProducto", "IdIngrediente").HasName("PK_Producto_Ingrediente");
                        j.ToTable("tb_Producto_Ingrediente");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("Id_Producto");
                        j.IndexerProperty<int>("IdIngrediente").HasColumnName("Id_Ingrediente");
                    });
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Usuar__3214EC073555B294");

            entity.ToTable("tb_Usuario");

            entity.Property(e => e.Contrasenna)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbVenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Venta__3214EC07978B3407");

            entity.ToTable("tb_Ventas");

            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbVenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ventas_Cliente");
        });

        modelBuilder.Entity<TbVentasProducto>(entity =>
        {
            entity.HasKey(e => new { e.IdVenta, e.IdProducto }).HasName("PK_Ventas_Producto");

            entity.ToTable("tb_Ventas_Producto");

            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TbVentasProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentasProducto_Producto");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.TbVentasProductos)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentasProducto_Ventas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
