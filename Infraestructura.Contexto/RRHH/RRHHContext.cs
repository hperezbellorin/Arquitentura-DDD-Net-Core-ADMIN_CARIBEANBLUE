using System;
using Dominio.Entidades.RRHH;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;


namespace Infraestructura.Contexto.RRHH
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

        public virtual DbSet<Tmenu> Tmenus { get; set; }
        public virtual DbSet<Tprivilegio> Tprivilegios { get; set; }
        public virtual DbSet<Tusuario> Tusuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseMySQL("Data Source=127.0.0.1;Initial Catalog=dbcarebeanblue  ;User=root;password=root;Connect Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tmenu>(entity =>
            {
                entity.HasKey(e => e.Idm)
                    .HasName("PRIMARY");

                entity.ToTable("tmenu");

                //entity.HasIndex(e => e.IdMenu, "fkprivilegio");

                entity.Property(e => e.Idm)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDM");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdMenu).HasColumnType("int(11)");

                entity.Property(e => e.IdUsuarioModificacion)
                    .HasColumnType("int(255)")
                    .HasColumnName("Id_UsuarioModificacion");

                entity.Property(e => e.Idwebform).HasColumnType("int(11)");

                entity.Property(e => e.Modulo).HasMaxLength(100);

                entity.Property(e => e.NameWebform)
                    .HasMaxLength(100)
                    .HasColumnName("Name_webform");

                entity.Property(e => e.PadreId).HasColumnType("int(11)");

                entity.Property(e => e.Posicion).HasColumnType("int(11)");

                entity.Property(e => e.ShowItem)
                    .HasColumnType("int(50)")
                    .HasColumnName("Show_item");
                  //  .HasComment("1: Devolucion  2: Reembolso");

                entity.Property(e => e.TipoMenu)
                    .HasColumnType("int(11)")
                    .HasColumnName("Tipo_Menu");

                entity.Property(e => e.Url).HasMaxLength(100);
            });

            modelBuilder.Entity<Tprivilegio>(entity =>
            {
                entity.ToTable("tprivilegio");

              //  entity.HasIndex(e => e.IdMenu, "id_menu");

               // entity.HasIndex(e => e.IdRol, "id_rol");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.IdMenu)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_menu");

                entity.Property(e => e.IdRol)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_rol");

                entity.Property(e => e.IdSubmenu)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_submenu");
            });

            modelBuilder.Entity<Tusuario>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PRIMARY");

                entity.ToTable("tusuarios");

             //   entity.HasIndex(e => e.IdRol, "IDRol");

                entity.Property(e => e.Iduser)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDuser");

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
                    .HasMaxLength(20)
                    .HasColumnName("IP");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Nombres).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Sexo).HasMaxLength(50);

                entity.Property(e => e.TelefoCelular).HasColumnType("int(11)");

                entity.Property(e => e.TelefonoDomicilio).HasColumnType("int(11)");

                entity.Property(e => e.TipoUser).HasColumnType("int(11)");

                entity.Property(e => e.Ubicacion).HasMaxLength(70);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
