using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_2.Models
{
    public partial class PruebaTecnicaContext : DbContext
    {
        public PruebaTecnicaContext()
        {
        }

        public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<MTDocumento> MDocumentos { get; set; }
        public virtual DbSet<MTEmail> MTEmail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=PruebaTecnica;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.Apellido_1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_1");

                entity.Property(e => e.Apellido_2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_2");

                entity.Property(e => e.Fecha_Act)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_Act");

                entity.Property(e => e.Fecha_Reg)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Reg");

                entity.Property(e => e.Id_Fkdocumento).HasColumnName("Id_FKDocumento");

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom_Compl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Nom_Compl");

                entity.Property(e => e.Nombre_1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_1");

                entity.Property(e => e.Nombre_2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_2");

                entity.Property(e => e.Nro_Documento).HasColumnName("Nro_documento");

                entity.HasOne(d => d.IdFkdocumentoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Id_Fkdocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_M_Documento");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.IdEmail);

                entity.ToTable("Email");

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Email_");

                entity.Property(e => e.FechAct)
                    .HasColumnType("datetime")
                    .HasColumnName("Fech_Act");

                entity.Property(e => e.FechReg)
                    .HasColumnType("datetime")
                    .HasColumnName("Fech_Reg");

                entity.Property(e => e.IdFkcliente).HasColumnName("Id_FKCliente");

                entity.Property(e => e.IdFktipo).HasColumnName("Id_FKTipo");

                entity.HasOne(d => d.IdFkclienteNavigation)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.IdFkcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Email_Clientes");

                entity.HasOne(d => d.IdFktipoNavigation)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.IdFktipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Email_M_TipoEmail");
            });

            modelBuilder.Entity<MTDocumento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.ToTable("M_TDocumento");

                entity.Property(e => e.DesDocumento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Des_documento");
            });

            modelBuilder.Entity<MTEmail>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.ToTable("MTEmail");

                entity.Property(e => e.DescTipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Desc_Tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
