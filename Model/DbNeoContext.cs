using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Calidad.Model;

public partial class DbNeoContext : DbContext
{
    public DbNeoContext()
    {
    }

    public DbNeoContext(DbContextOptions<DbNeoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Centro> Centros { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Linea> Lineas { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Pnccausante> Pnccausantes { get; set; }

    public virtual DbSet<PncdisDefi> PncdisDefis { get; set; }

    public virtual DbSet<Pncestado> Pncestados { get; set; }

    public virtual DbSet<Pncidentif> Pncidentifs { get; set; }

    public virtual DbSet<PncproDisp> PncproDisps { get; set; }

    public virtual DbSet<Pncriesgo> Pncriesgos { get; set; }

    public virtual DbSet<Pnctipo> Pnctipos { get; set; }

    public virtual DbSet<Pncunidad> Pncunidads { get; set; }

    public virtual DbSet<ProNoCon> ProNoCons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.20.1.60\\DESARROLLO;Initial Catalog=DbNeo;TrustServerCertificate=True;Persist Security Info=True;User ID=UsrEncuesta;Password=Enc2022**Ing");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Centro>(entity =>
        {
            entity.HasKey(e => e.IdCentro);

            entity.ToTable("Centro", tb => tb.HasComment("centro de produccion"));

            entity.Property(e => e.IdCentro).HasComment("identificador del centro");
            entity.Property(e => e.Cdetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Detalle del centro")
                .HasColumnName("CDetalle");
            entity.Property(e => e.Cestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("CEstado");
            entity.Property(e => e.Cnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre del centro")
                .HasColumnName("CNom");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Centros)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_Centro_Empresa");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.IdDivision);

            entity.ToTable("Division");

            entity.Property(e => e.Ddetalle)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DDetalle");
            entity.Property(e => e.Destado).HasColumnName("DEstado");
            entity.Property(e => e.Dnombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DNombre");

            entity.HasOne(d => d.IdCentroNavigation).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.IdCentro)
                .HasConstraintName("FK_Division_Centro");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("Empresa");

            entity.Property(e => e.Edescri)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDescri");
            entity.Property(e => e.Eestado).HasColumnName("EEstado");
            entity.Property(e => e.Enombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENombre");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_Pais");
        });

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.IdLinea);

            entity.ToTable("Linea", tb => tb.HasComment("linea de produccion"));

            entity.Property(e => e.IdLinea).HasComment("identificador de la linea");
            entity.Property(e => e.IdCentro).HasComment("identificador del centro");
            entity.Property(e => e.LcenCos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LCenCos");
            entity.Property(e => e.Ldetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Detalle de la linea")
                .HasColumnName("LDetalle");
            entity.Property(e => e.Lestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("LEstado");
            entity.Property(e => e.Lnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre de la linea")
                .HasColumnName("LNom");
            entity.Property(e => e.Lofic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOFIC");

            entity.HasOne(d => d.IdCentroNavigation).WithMany(p => p.Lineas)
                .HasForeignKey(d => d.IdCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Linea_Centro1");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.Lineas)
                .HasForeignKey(d => d.IdDivision)
                .HasConstraintName("FK_Linea_Division");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.Property(e => e.Pestado).HasColumnName("PEstado");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PNombre");
        });

        modelBuilder.Entity<Pnccausante>(entity =>
        {
            entity.HasKey(e => e.IdCausante);

            entity.ToTable("PNCCausante");

            entity.Property(e => e.Cdescri)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CDescri");
            entity.Property(e => e.Cestado).HasColumnName("CEstado");
            entity.Property(e => e.Cnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNombre");
        });

        modelBuilder.Entity<PncdisDefi>(entity =>
        {
            entity.HasKey(e => e.IdDisDefi);

            entity.ToTable("PNCDisDefi");

            entity.Property(e => e.Dddescri)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DDDescri");
            entity.Property(e => e.Ddestado).HasColumnName("DDEstado");
            entity.Property(e => e.Ddnombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("DDNombre");
        });

        modelBuilder.Entity<Pncestado>(entity =>
        {
            entity.HasKey(e => e.IdEstado);

            entity.ToTable("PNCEstado");

            entity.Property(e => e.Edescri)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EDescri");
            entity.Property(e => e.Enombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENombre");
            entity.Property(e => e.Estatus).HasColumnName("EStatus");
        });

        modelBuilder.Entity<Pncidentif>(entity =>
        {
            entity.HasKey(e => e.IdIdentif);

            entity.ToTable("PNCIdentif");

            entity.Property(e => e.Idescri)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("IDescri");
            entity.Property(e => e.Iestado).HasColumnName("IEstado");
            entity.Property(e => e.Inombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("INombre");
        });

        modelBuilder.Entity<PncproDisp>(entity =>
        {
            entity.HasKey(e => e.IdProDisp);

            entity.ToTable("PNCProDisp");

            entity.Property(e => e.Pddescri)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PDDescri");
            entity.Property(e => e.Pdestado).HasColumnName("PDEstado");
            entity.Property(e => e.Pdnombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("PDNombre");
        });

        modelBuilder.Entity<Pncriesgo>(entity =>
        {
            entity.HasKey(e => e.IdRiesgo);

            entity.ToTable("PNCRiesgo");

            entity.Property(e => e.Rdescri)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RDescri");
            entity.Property(e => e.Restado).HasColumnName("REstado");
            entity.Property(e => e.Rnombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("RNombre");
        });

        modelBuilder.Entity<Pnctipo>(entity =>
        {
            entity.HasKey(e => e.IdTipo);

            entity.ToTable("PNCTipo");

            entity.Property(e => e.Tdescri)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TDescri");
            entity.Property(e => e.Testado).HasColumnName("TEstado");
            entity.Property(e => e.Tnombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("TNombre");
        });

        modelBuilder.Entity<Pncunidad>(entity =>
        {
            entity.HasKey(e => e.IdUnidad);

            entity.ToTable("PNCUnidad");

            entity.Property(e => e.Udescri)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("UDescri");
            entity.Property(e => e.Uestado).HasColumnName("UEstado");
            entity.Property(e => e.Unombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UNombre");
        });

        modelBuilder.Entity<ProNoCon>(entity =>
        {
            entity.HasKey(e => e.IdProNoCon);

            entity.ToTable("ProNoCon", "his");

            entity.Property(e => e.IdProNoCon).HasColumnName("idProNoCon");
            entity.Property(e => e.Pnccantida).HasColumnName("PNCCantida");
            entity.Property(e => e.Pnccargador)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PNCCargador");
            entity.Property(e => e.PnccauLibe)
                .IsUnicode(false)
                .HasColumnName("PNCCauLibe");
            entity.Property(e => e.Pnccausa)
                .IsUnicode(false)
                .HasColumnName("PNCCausa");
            entity.Property(e => e.PnccodProd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PNCCodProd");
            entity.Property(e => e.Pncconsecu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PNCConsecu");
            entity.Property(e => e.PncdesProd)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PNCDesProd");
            entity.Property(e => e.Pncfecha)
                .HasColumnType("date")
                .HasColumnName("PNCFecha");
            entity.Property(e => e.Pncinconfo)
                .IsUnicode(false)
                .HasColumnName("PNCInconfo");
            entity.Property(e => e.PncindLibe)
                .IsUnicode(false)
                .HasColumnName("PNCIndLibe");
            entity.Property(e => e.Pnclote)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PNCLote");

            entity.HasOne(d => d.IdCausanteNavigation).WithMany(p => p.ProNoCons)
                .HasForeignKey(d => d.IdCausante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProNoCon_PNCCausante");

            entity.HasOne(d => d.IdDisDefiNavigation).WithMany(p => p.ProNoCons)
                .HasForeignKey(d => d.IdDisDefi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProNoCon_PNCDisDefi");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.ProNoCons)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProNoCon_PNCEstado");

            entity.HasOne(d => d.IdIdentifNavigation).WithMany(p => p.ProNoCons)
                .HasForeignKey(d => d.IdIdentif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProNoCon_PNCIdentif");

            entity.HasOne(d => d.IdLugaEvenNavigation).WithMany(p => p.ProNoCons)
                .HasForeignKey(d => d.IdLugaEven)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProNoCon_Linea");

            entity.HasOne(d => d.IdProDispNavigation).WithMany(p => p.ProNoCons)
                .HasForeignKey(d => d.IdProDisp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProNoCon_PNCProDisp");

            entity.HasOne(d => d.IdRiesgoNavigation).WithMany(p => p.ProNoCons)
                .HasForeignKey(d => d.IdRiesgo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProNoCon_PNCRiesgo");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.ProNoCons)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProNoCon_PNCTipo");

            entity.HasOne(d => d.IdUnidadNavigation).WithMany(p => p.ProNoCons)
                .HasForeignKey(d => d.IdUnidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProNoCon_PNCUnidad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
