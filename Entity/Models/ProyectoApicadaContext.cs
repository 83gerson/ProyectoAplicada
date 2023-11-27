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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-I7JHR1PM;User Id=sa;Password=dylan2604;Initial Catalog=ProyectoApicada;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbExpediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Exped__3214EC07B7D2A595");

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
            entity.HasKey(e => e.Id).HasName("PK__tb_Ingre__3214EC075E44EA3A");

            entity.ToTable("tb_Ingrediente");

            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Produ__3214EC07D4153EA0");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
