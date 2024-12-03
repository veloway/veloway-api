using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class VelowayDbContext : DbContext
{
    public VelowayDbContext()
    {
    }

    public VelowayDbContext(DbContextOptions<VelowayDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Checkpoint> Checkpoints { get; set; }

    public virtual DbSet<Conductor> Conductores { get; set; }

    public virtual DbSet<Domicilio> Domicilios { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<EstadoConductor> EstadosConductores { get; set; }

    public virtual DbSet<EstadoEnvio> EstadosEnvios { get; set; }

    public virtual DbSet<FichaMedica> FichasMedicas { get; set; }

    public virtual DbSet<Licencia> Licencias { get; set; }

    public virtual DbSet<Localidad> Localidades { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<TipoVehiculo> TiposVehiculos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=ep-rough-term-a5bs9loc.us-east-2.aws.neon.tech;Port=5432;Database=veloway_db;User Id=veloway_db_owner;Password=iBYCSmV79Qct");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Checkpoint>(entity =>
        {
            entity.HasKey(e => e.IdCheckpoint).HasName("checkpoints_pkey");

            entity.ToTable("checkpoints");

            entity.Property(e => e.IdCheckpoint).HasColumnName("id_checkpoint");
            entity.Property(e => e.IdViaje).HasColumnName("id_viaje");
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Longitud).HasColumnName("longitud");
            entity.Property(e => e.Numero).HasColumnName("numero");

            entity.HasOne(d => d.IdViajeNavigation).WithMany(p => p.Checkpoints)
                .HasForeignKey(d => d.IdViaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("checkpoints_id_viaje_fkey");
        });

        modelBuilder.Entity<Conductor>(entity =>
        {
            entity.HasKey(e => e.IdConductor).HasName("conductores_pkey");

            entity.ToTable("conductores");

            entity.HasIndex(e => e.Dni, "conductores_dni_key").IsUnique();

            entity.HasIndex(e => e.IdVehiculo, "conductores_id_vehiculo_key").IsUnique();

            entity.Property(e => e.IdConductor)
                .ValueGeneratedNever()
                .HasColumnName("id_conductor");
            entity.Property(e => e.Compartirfichamedica).HasColumnName("compartirfichamedica");
            entity.Property(e => e.Dni).HasColumnName("dni");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");

            entity.HasOne(d => d.IdConductorNavigation).WithOne(p => p.Conductore)
                .HasForeignKey<Conductor>(d => d.IdConductor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conductores_id_conductor_fkey");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Conductores)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conductores_id_estado_fkey");

            entity.HasOne(d => d.IdVehiculoNavigation).WithOne(p => p.Conductore)
                .HasForeignKey<Conductor>(d => d.IdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conductores_id_vehiculo_fkey");
        });

        modelBuilder.Entity<Domicilio>(entity =>
        {
            entity.HasKey(e => e.IdDomicilio).HasName("domicilios_pkey");

            entity.ToTable("domicilios");

            entity.HasIndex(e => e.IdUsuario, "domicilios_id_usuario_key").IsUnique();

            entity.Property(e => e.IdDomicilio).HasColumnName("id_domicilio");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .HasColumnName("calle");
            entity.Property(e => e.Depto)
                .HasMaxLength(5)
                .HasColumnName("depto");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.IdLocalidad).HasColumnName("id_localidad");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Piso).HasColumnName("piso");

            entity.HasOne(d => d.IdLocalidadNavigation).WithMany(p => p.Domicilios)
                .HasForeignKey(d => d.IdLocalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("domicilios_id_localidad_fkey");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Domicilio)
                .HasForeignKey<Domicilio>(d => d.IdUsuario)
                .HasConstraintName("domicilios_id_usuario_fkey");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.NroSeguimiento).HasName("envios_pkey");

            entity.ToTable("envios");

            entity.Property(e => e.NroSeguimiento)
                .ValueGeneratedNever()
                .HasColumnName("nro_seguimiento");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdDestino).HasColumnName("id_destino");
            entity.Property(e => e.IdEstado)
                .HasDefaultValue(1)
                .HasColumnName("id_estado");
            entity.Property(e => e.IdOrigen).HasColumnName("id_origen");
            entity.Property(e => e.PesoGramos)
                .HasPrecision(10, 2)
                .HasColumnName("peso_gramos");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Envios)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("envios_id_cliente_fkey");

            entity.HasOne(d => d.IdDestinoNavigation).WithMany(p => p.EnvioIdDestinoNavigations)
                .HasForeignKey(d => d.IdDestino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("envios_id_destino_fkey");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Envios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("envios_id_estado_fkey");

            entity.HasOne(d => d.IdOrigenNavigation).WithMany(p => p.EnvioIdOrigenNavigations)
                .HasForeignKey(d => d.IdOrigen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("envios_id_origen_fkey");
        });

        modelBuilder.Entity<EstadoConductor>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("estados_conductores_pkey");

            entity.ToTable("estados_conductores");

            entity.HasIndex(e => e.Nombre, "estados_conductores_nombre_key").IsUnique();

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<EstadoEnvio>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("estados_envio_pkey");

            entity.ToTable("estados_envio");

            entity.HasIndex(e => e.Nombre, "estados_envio_nombre_key").IsUnique();

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<FichaMedica>(entity =>
        {
            entity.HasKey(e => e.IdFichaMedica).HasName("fichas_medicas_pkey");

            entity.ToTable("fichas_medicas");

            entity.HasIndex(e => e.IdConductor, "fichas_medicas_id_conductor_key").IsUnique();

            entity.Property(e => e.IdFichaMedica).HasColumnName("id_ficha_medica");
            entity.Property(e => e.IdConductor).HasColumnName("id_conductor");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.TelefonoEmergencia)
                .HasMaxLength(20)
                .HasColumnName("telefono_emergencia");

            entity.HasOne(d => d.IdConductorNavigation).WithOne(p => p.FichasMedica)
                .HasForeignKey<FichaMedica>(d => d.IdConductor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fichas_medicas_id_conductor_fkey");
        });

        modelBuilder.Entity<Licencia>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("licencias_pkey");

            entity.ToTable("licencias");

            entity.HasIndex(e => e.IdConductor, "licencias_id_conductor_key").IsUnique();

            entity.Property(e => e.Numero)
                .ValueGeneratedNever()
                .HasColumnName("numero");
            entity.Property(e => e.Categoria)
                .HasMaxLength(30)
                .HasColumnName("categoria");
            entity.Property(e => e.Fechavencimiento).HasColumnName("fechavencimiento");
            entity.Property(e => e.IdConductor).HasColumnName("id_conductor");

            entity.HasOne(d => d.IdConductorNavigation).WithOne(p => p.Licencia)
                .HasForeignKey<Licencia>(d => d.IdConductor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("licencias_id_conductor_fkey");
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.HasKey(e => e.IdLocalidad).HasName("localidades_pkey");

            entity.ToTable("localidades");

            entity.Property(e => e.IdLocalidad).HasColumnName("id_localidad");
            entity.Property(e => e.CodigoPostal).HasColumnName("codigo_postal");
            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("localidades_id_provincia_fkey");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("marcas_pkey");

            entity.ToTable("marcas");

            entity.Property(e => e.IdMarca).HasColumnName("id_marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.IdModelo).HasName("modelos_pkey");

            entity.ToTable("modelos");

            entity.Property(e => e.IdModelo).HasColumnName("id_modelo");
            entity.Property(e => e.IdMarca).HasColumnName("id_marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("modelos_id_marca_fkey");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("provincias_pkey");

            entity.ToTable("provincias");

            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdTipoVehiculo).HasName("tipos_vehiculos_pkey");

            entity.ToTable("tipos_vehiculos");

            entity.Property(e => e.IdTipoVehiculo).HasColumnName("id_tipo_vehiculo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Dni, "usuarios_dni_key").IsUnique();

            entity.HasIndex(e => e.Email, "usuarios_email_key").IsUnique();

            entity.HasIndex(e => e.Password, "usuarios_password_key").IsUnique();

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni).HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EsConductor).HasColumnName("es_conductor");
            entity.Property(e => e.FechaNac).HasColumnName("fecha_nac");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("vehiculos_pkey");

            entity.ToTable("vehiculos");

            entity.HasIndex(e => e.Patente, "vehiculos_patente_key").IsUnique();

            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Color)
                .HasMaxLength(15)
                .HasColumnName("color");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.IdModelo).HasColumnName("id_modelo");
            entity.Property(e => e.IdTipoVehiculo).HasColumnName("id_tipo_vehiculo");
            entity.Property(e => e.NombreSeguro)
                .HasMaxLength(20)
                .HasColumnName("nombre_seguro");
            entity.Property(e => e.Patente)
                .HasMaxLength(20)
                .HasColumnName("patente");

            entity.HasOne(d => d.IdModeloNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdModelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vehiculos_id_modelo_fkey");

            entity.HasOne(d => d.IdTipoVehiculoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdTipoVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vehiculos_id_tipo_vehiculo_fkey");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.IdViaje).HasName("viajes_pkey");

            entity.ToTable("viajes");

            entity.HasIndex(e => e.NroSeguimiento, "viajes_nro_seguimiento_key").IsUnique();

            entity.Property(e => e.IdViaje).HasColumnName("id_viaje");
            entity.Property(e => e.CheckpointActual)
                .HasDefaultValue(1)
                .HasColumnName("checkpoint_actual");
            entity.Property(e => e.FechaFin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdConductor).HasColumnName("id_conductor");
            entity.Property(e => e.NroSeguimiento).HasColumnName("nro_seguimiento");

            entity.HasOne(d => d.IdConductorNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdConductor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("viajes_id_conductor_fkey");

            entity.HasOne(d => d.NroSeguimientoNavigation).WithOne(p => p.Viaje)
                .HasForeignKey<Viaje>(d => d.NroSeguimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("viajes_nro_seguimiento_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
