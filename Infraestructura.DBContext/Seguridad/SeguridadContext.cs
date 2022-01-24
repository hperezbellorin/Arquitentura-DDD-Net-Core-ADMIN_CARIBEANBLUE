using System;
using Dominio.Entidades.ADMIN;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infraestructura.DBContext.Seguridad
{
    public partial class SeguridadContext : IdentityDbContext<Aspnetusers, Aspnetroles, string, Aspnetuserclaims, Aspnetuserroles, Aspnetuserlogins, Aspnetroleclaims,Aspnetusertokens>
    {
    
        public SeguridadContext(DbContextOptions<SeguridadContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }


        public virtual DbSet<Aspetmenus> Aspetmenus { get; set; }
        public virtual DbSet<Aspnetmiembros> Aspnetmiembros { get; set; }
        public virtual DbSet<Aspnetprivilegios> Aspnetprivilegios { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

               
                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Email);

                entity.Property(e => e.NormalizedEmail);

                entity.Property(e => e.NormalizedUserName);

                entity.Property(e => e.UserName);
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspetmenus>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PRIMARY");

                entity.ToTable("aspetmenus");

                entity.Property(e => e.MenuId).HasColumnType("int(11)");

                entity.Property(e => e.Accion).HasMaxLength(255);

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.ControlId).HasColumnType("int(11)");

                entity.Property(e => e.Controlador).HasMaxLength(100);

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.Icono).HasMaxLength(255);

                entity.Property(e => e.IdUsuarioModificacion)
                    .HasColumnName("Id_UsuarioModificacion")
                    .HasColumnType("int(255)");

                entity.Property(e => e.Modulo).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.Orden).HasColumnType("int(11)");

                entity.Property(e => e.PadreId).HasColumnType("int(11)");

                entity.Property(e => e.ShowItem)
                    .HasColumnName("Show_item")
                    .HasColumnType("int(50)")
                    .HasComment("1: Devolucion  2: Reembolso");

                entity.Property(e => e.TipoMenu)
                    .HasColumnName("Tipo_Menu")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Aspnetmiembros>(entity =>
            {
                entity.HasKey(e => e.MiembroId)
                    .HasName("PRIMARY");

                entity.ToTable("aspnetmiembros");

                entity.Property(e => e.Apellidos).HasMaxLength(255);

                entity.Property(e => e.Cedula).HasMaxLength(255);

                entity.Property(e => e.Correo).HasMaxLength(255);

                entity.Property(e => e.Direccion).HasMaxLength(255);

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.Nombres).HasMaxLength(255);

                entity.Property(e => e.RoleId).HasMaxLength(767);

                entity.Property(e => e.Telefono).HasColumnType("int(11)");

                entity.Property(e => e.UsuarioId).HasMaxLength(767);
            });

            modelBuilder.Entity<Aspnetprivilegios>(entity =>
            {
                entity.ToTable("aspnetprivilegios");

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



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
