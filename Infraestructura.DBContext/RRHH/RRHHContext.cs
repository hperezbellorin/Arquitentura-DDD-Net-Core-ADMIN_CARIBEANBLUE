using System;
using Dominio.Entidades.RRHH;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infraestructura.DBContext.RRHH
{
    public partial class RRHHContext : DbContext
    {
        public RRHHContext()
        {
        }

        public RRHHContext(DbContextOptions<RRHHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tmenu> Tmenu { get; set; }
        public virtual DbSet<Tprivilegio> Tprivilegio { get; set; }
        public virtual DbSet<Tusuarios> Tusuarios { get; set; }

        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Marcaciones> Marcaciones { get; set; }
        public virtual DbSet<Relojes> Relojes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tmenu>(entity =>
            {
                entity.HasKey(e => e.Idm)
                    .HasName("PRIMARY");

                entity.ToTable("tmenu");

                entity.HasIndex(e => e.IdMenu)
                    .HasName("fkprivilegio");

                entity.Property(e => e.Idm)
                    .HasColumnName("IDM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdMenu).HasColumnType("int(11)");

                entity.Property(e => e.IdUsuarioModificacion)
                    .HasColumnName("Id_UsuarioModificacion")
                    .HasColumnType("int(255)");

                entity.Property(e => e.Idwebform).HasColumnType("int(11)");

                entity.Property(e => e.Modulo).HasMaxLength(100);

                entity.Property(e => e.NameWebform)
                    .HasColumnName("Name_webform")
                    .HasMaxLength(100);

                entity.Property(e => e.PadreId).HasColumnType("int(11)");

                entity.Property(e => e.Posicion).HasColumnType("int(11)");

                entity.Property(e => e.ShowItem)
                    .HasColumnName("Show_item")
                    .HasColumnType("int(50)")
                    .HasComment("1: Devolucion  2: Reembolso");

                entity.Property(e => e.TipoMenu)
                    .HasColumnName("Tipo_Menu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Url).HasMaxLength(100);
            });

            modelBuilder.Entity<Tprivilegio>(entity =>
            {
                entity.ToTable("tprivilegio");

                entity.HasIndex(e => e.IdMenu)
                    .HasName("id_menu");

                entity.HasIndex(e => e.IdRol)
                    .HasName("id_rol");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMenu)
                    .HasColumnName("id_menu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSubmenu)
                    .HasColumnName("id_submenu")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Tusuarios>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PRIMARY");

                entity.ToTable("tusuarios");

                entity.HasIndex(e => e.IdRol)
                    .HasName("IDRol");

                entity.Property(e => e.Iduser)
                    .HasColumnName("IDuser")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido1).HasMaxLength(50);

                entity.Property(e => e.Apellido2).HasMaxLength(50);

                entity.Property(e => e.Cedula).HasMaxLength(20);

                entity.Property(e => e.Ciudad).HasColumnType("int(11)");

                entity.Property(e => e.Departamento).HasColumnType("int(11)");

                entity.Property(e => e.Direccion).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnType("int(11)");

                entity.Property(e => e.EstadoCivil).HasMaxLength(20);

                entity.Property(e => e.FechaInactivo).HasMaxLength(50);

                entity.Property(e => e.IdRol).HasColumnType("int(11)");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(20);

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombres).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Sexo).HasMaxLength(50);

                entity.Property(e => e.TelefoCelular).HasColumnType("int(11)");

                entity.Property(e => e.TelefonoDomicilio).HasColumnType("int(11)");

                entity.Property(e => e.TipoUser).HasColumnType("int(11)");

                entity.Property(e => e.Ubicacion).HasMaxLength(70);
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.ToTable("empleados");

                entity.Property(e => e.Id).HasColumnType("int(10)");

                entity.Property(e => e.Apellido1).HasMaxLength(20);

                entity.Property(e => e.Apellido2).HasMaxLength(20);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Correo).HasMaxLength(70);

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Direccion).HasMaxLength(255);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.EstadoCivil).HasMaxLength(20);

                entity.Property(e => e.Image).HasColumnType("longtext");

                entity.Property(e => e.IsActive).HasColumnType("bit(1)");

                entity.Property(e => e.NameImage).HasMaxLength(70);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Marcaciones>(entity =>
            {
                entity.ToTable("marcaciones");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdEmpleado).HasColumnType("int(11)");

                entity.Property(e => e.IdReloj).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Relojes>(entity =>
            {
                entity.ToTable("relojes");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DirIp)
                    .IsRequired()
                    .HasColumnName("DirIP")
                    .HasMaxLength(15);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Puerto)
                    .IsRequired()
                    .HasMaxLength(4);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
