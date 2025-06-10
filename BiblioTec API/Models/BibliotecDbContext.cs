using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BiblioTec_API.Models;

public partial class BibliotecDbContext : DbContext
{
    public BibliotecDbContext()
    {
    }

    public BibliotecDbContext(DbContextOptions<BibliotecDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administradores> Administradores { get; set; }

    public virtual DbSet<Carreras> Carreras { get; set; }

    public virtual DbSet<Ejemplares> Ejemplares { get; set; }

    public virtual DbSet<Estudiantes> Estudiantes { get; set; }

    public virtual DbSet<Maestros> Maestros { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Prestamos> Prestamos { get; set; }

    public virtual DbSet<PublicoGeneral> PublicoGenerals { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Sanciones> Sanciones { get; set; }

    public virtual DbSet<TipoMaterial> TipoMaterials { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administradores>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__administ__0FE822AAEF1BBFA3");

            entity.ToTable("administradores");

            entity.HasIndex(e => e.IdUsuario, "UQ__administ__4E3E04AC15A71277").IsUnique();

            entity.Property(e => e.IdAdministrador).HasColumnName("id_administrador");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Administradore)
                .HasForeignKey<Administradores>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__administr__id_us__48CFD27E");
        });

        modelBuilder.Entity<Carreras>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PK__carreras__82525F26EFF2C64D");

            entity.ToTable("carreras");

            entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");
            entity.Property(e => e.NombreCarrera)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_carrera");
        });

        modelBuilder.Entity<Ejemplares>(entity =>
        {
            entity.HasKey(e => e.IdEjemplar).HasName("PK__ejemplar__5E0D89AD734FE00B");

            entity.ToTable("ejemplares");

            entity.HasIndex(e => e.CodigoInventario, "UQ__ejemplar__2C4D9A177702DED9").IsUnique();

            entity.Property(e => e.IdEjemplar).HasColumnName("id_ejemplar");
            entity.Property(e => e.CodigoInventario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codigo_inventario");
            entity.Property(e => e.IdMaterial).HasColumnName("id_material");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.Ejemplares)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ejemplare__id_ma__571DF1D5");
        });

        modelBuilder.Entity<Estudiantes>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__estudian__E0B2763C9B6AEAD5");

            entity.ToTable("estudiantes");

            entity.HasIndex(e => e.IdUsuario, "UQ__estudian__4E3E04AC17BC5A6C").IsUnique();

            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Matricula).HasColumnName("matricula");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__estudiant__id_ca__412EB0B6");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Estudiante)
                .HasForeignKey<Estudiantes>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__estudiant__id_us__403A8C7D");
        });

        modelBuilder.Entity<Maestros>(entity =>
        {
            entity.HasKey(e => e.IdMaestro).HasName("PK__maestros__5509BEDB7091F47C");

            entity.ToTable("maestros");

            entity.HasIndex(e => e.IdUsuario, "UQ__maestros__4E3E04AC63683782").IsUnique();

            entity.Property(e => e.IdMaestro).HasColumnName("id_maestro");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NoEmpleado).HasColumnName("no_empleado");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Maestro)
                .HasForeignKey<Maestros>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__maestros__id_usu__44FF419A");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("PK__material__81E99B8313523788");

            entity.ToTable("material");

            entity.Property(e => e.IdMaterial).HasColumnName("id_material");
            entity.Property(e => e.AnioPublicacion).HasColumnName("anio_publicacion");
            entity.Property(e => e.Autor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.Editorial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("editorial");
            entity.Property(e => e.IdTipoMaterial).HasColumnName("id_tipo_material");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.oTipoMaterial).WithMany(p => p.Materials)
                .HasForeignKey(d => d.IdTipoMaterial)
                .HasConstraintName("FK__material__id_tip__534D60F1");
        });

        modelBuilder.Entity<Prestamos>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__prestamo__5E87BE2771C69A40");

            entity.ToTable("prestamos");

            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.EstadoLibro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado_libro");
            entity.Property(e => e.FechaLimite).HasColumnName("fecha_limite");
            entity.Property(e => e.FechaPrestamo).HasColumnName("fecha_prestamo");
            entity.Property(e => e.IdEjemplar).HasColumnName("id_ejemplar");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdEjemplarNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdEjemplar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__prestamos__id_ej__5BE2A6F2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__prestamos__id_us__5AEE82B9");
        });

        modelBuilder.Entity<PublicoGeneral>(entity =>
        {
            entity.HasKey(e => e.IdPublico).HasName("PK__publico___660B0C109474B263");

            entity.ToTable("publico_general");

            entity.HasIndex(e => e.Curp, "UQ__publico___2CDDD1945A810D5F").IsUnique();

            entity.HasIndex(e => e.IdUsuario, "UQ__publico___4E3E04ACFB541A80").IsUnique();

            entity.Property(e => e.IdPublico).HasColumnName("id_publico");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("curp");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.PublicoGeneral)
                .HasForeignKey<PublicoGeneral>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__publico_g__id_us__4D94879B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__6ABCB5E00298499A");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Sancione>(entity =>
        {
            entity.HasKey(e => e.IdSancion).HasName("PK__sancione__40D35AF3267EC8A0");

            entity.ToTable("sanciones");

            entity.Property(e => e.IdSancion).HasColumnName("id_sancion");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado_pago");
            entity.Property(e => e.FechaPago).HasColumnName("fecha_pago");
            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.MontoMulta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto_multa");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.Sanciones)
                .HasForeignKey(d => d.IdPrestamo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sanciones__id_pr__60A75C0F");
        });

        modelBuilder.Entity<TipoMaterial>(entity =>
        {
            entity.HasKey(e => e.IdTipoMaterial).HasName("PK__tipo_mat__20B07730E9987E5E");

            entity.ToTable("tipo_material");

            entity.Property(e => e.IdTipoMaterial).HasColumnName("id_tipo_material");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD6C44292D");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Correo, "UQ__usuarios__2A586E0B03584B34").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_paterno");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuarios__id_rol__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
