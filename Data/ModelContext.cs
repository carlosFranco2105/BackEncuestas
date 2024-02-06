using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Entities.Models;

namespace Data;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estadistica> Estadisticas { get; set; }

    public virtual DbSet<MailEncuestas> MailEncuesta { get; set; }

    public virtual DbSet<MailFormato> MailFormatos { get; set; }

    public virtual DbSet<MailLog> MailLogs { get; set; }

    public virtual DbSet<NombreEncuesta> NombreEncuesta { get; set; }

    public virtual DbSet<Respuesta> Respuesta { get; set; }

    public virtual DbSet<SessionItem> Sessions { get; set; }    

    public virtual DbSet<UserItem> Users { get; set; }
    public virtual DbSet<VwEstructura> VwEstructuras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("Name=OracleDBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ENCUESTAMOVIL_USER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Estadistica>(entity =>
        {
            entity.HasKey(e => new { e.IdEncuesta, e.IdRespuesta }).HasName("ESTADISTICA_PK");

            entity.ToTable("ESTADISTICA", "ENCUESTAMOVIL");

            entity.Property(e => e.IdEncuesta)
                .HasPrecision(18)
                .HasColumnName("ID_ENCUESTA");
            entity.Property(e => e.IdRespuesta)
                .HasPrecision(18)
                .HasColumnName("ID_RESPUESTA");
            entity.Property(e => e.DesdeIntranet)
                .HasDefaultValueSql("1")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DESDE_INTRANET");
            entity.Property(e => e.DesdeWeb)
                .HasDefaultValueSql("1")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DESDE_WEB");
            entity.Property(e => e.FechaHora)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("FECHA_HORA");
            entity.Property(e => e.Plataforma)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PLATAFORMA");

            entity.HasOne(d => d.IdEncuestaNavigation).WithMany(p => p.Estadisticas)
                .HasForeignKey(d => d.IdEncuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ESTADISTICA_NOMBRE_ENCUES_FK1");
        });

        modelBuilder.Entity<MailEncuestas>(entity =>
        {
            entity.HasKey(e => e.IdMailEncuesta).HasName("MAIL_ENCUESTA_PK");

            entity.ToTable("MAIL_ENCUESTA", "ENCUESTAMOVIL");

            entity.Property(e => e.IdMailEncuesta)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_MAIL_ENCUESTA");
            entity.Property(e => e.FfDesde)
                .HasColumnType("DATE")
                .HasColumnName("FF_DESDE");
            entity.Property(e => e.FfHasta)
                .HasColumnType("DATE")
                .HasColumnName("FF_HASTA");
            entity.Property(e => e.IdEncuesta)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_ENCUESTA");
            entity.Property(e => e.IdFormatoMail)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_FORMATO_MAIL");
            entity.Property(e => e.Query)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("QUERY");

            entity.HasOne(d => d.IdMailEncuestaNavigation).WithOne(p => p.MailEncuesta)
                .HasForeignKey<MailEncuestas>(d => d.IdMailEncuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MAIL_ENCUESTA_FK1");
        });

        modelBuilder.Entity<MailFormato>(entity =>
        {
            entity.HasKey(e => e.IdMailFormato).HasName("MAIL_FORMATO_PK");

            entity.ToTable("MAIL_FORMATO", "ENCUESTAMOVIL");

            entity.Property(e => e.IdMailFormato)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_MAIL_FORMATO");
            entity.Property(e => e.FfBaja)
                .HasColumnType("DATE")
                .HasColumnName("FF_BAJA");
            entity.Property(e => e.MailBody)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("MAIL_BODY");
            entity.Property(e => e.MailSubject)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAIL_SUBJECT");
        });

        modelBuilder.Entity<MailLog>(entity =>
        {
            entity.HasKey(e => new { e.IdEncuesta, e.FfEnvio }).HasName("MAIL_LOG_PK");

            entity.ToTable("MAIL_LOG", "ENCUESTAMOVIL");

            entity.Property(e => e.IdEncuesta)
                .HasColumnType("NUMBER")
                .HasColumnName("ID_ENCUESTA");
            entity.Property(e => e.FfEnvio)
                .HasColumnType("DATE")
                .HasColumnName("FF_ENVIO");
            entity.Property(e => e.Cantidad)
                .HasColumnType("NUMBER")
                .HasColumnName("CANTIDAD");
        });

        modelBuilder.Entity<NombreEncuesta>(entity =>
        {
            entity.HasKey(e => e.IdEncuesta).HasName("SYS_C0079673");

            entity.ToTable("NOMBRE_ENCUESTA", "ENCUESTAMOVIL");

            entity.Property(e => e.IdEncuesta)
                .HasPrecision(18)
                .ValueGeneratedNever()
                .HasColumnName("ID_ENCUESTA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Respuesta>(entity =>
        {
            entity.HasKey(e => new { e.IdEncuesta, e.IdRespuesta, e.IdPregunta }).HasName("RESPUESTA_PK");

            entity.ToTable("RESPUESTA", "ENCUESTAMOVIL");

            entity.Property(e => e.IdEncuesta)
                .HasPrecision(18)
                .HasColumnName("ID_ENCUESTA");
            entity.Property(e => e.IdRespuesta)
                .HasPrecision(18)
                .HasColumnName("ID_RESPUESTA");
            entity.Property(e => e.IdPregunta)
                .HasPrecision(8)
                .HasColumnName("ID_PREGUNTA");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.Valor)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("VALOR");

            entity.HasOne(d => d.IdEncuestaNavigation).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.IdEncuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RESPUESTA_NOMBRE_ENCUESTA_FK1");
        });
        modelBuilder.Entity<SessionItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SESSIONS_PK");

            entity.ToTable("SESSIONS", "ENCUESTAMOVIL");
            entity.Property(e => e.Id)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.OpenedAt)
                .HasColumnType("DATE")
                .HasColumnName("OPENEDAT");
            entity.Property(e => e.UserId)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("USERID");
        });

        modelBuilder.Entity<UserItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("USERS_PK");

            entity.ToTable("USERS", "ENCUESTAMOVIL");


            entity.Property(e => e.Id)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DISPLAYNAME");
            entity.Property(e => e.ExpiredAt)
                .HasColumnType("DATE")
                .HasColumnName("EXPIREDAT");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("PASSWORDHASH");
            entity.Property(e => e.Role)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("ROLE");
            entity.Property(e => e.Username)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<VwEstructura>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_ESTRUCTURA", "ENCUESTAMOVIL");

            entity.Property(e => e.Abreviatura)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ABREVIATURA");
            entity.Property(e => e.ApellidoJefe)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_JEFE");
            entity.Property(e => e.CodAtributo)
                .HasPrecision(4)
                .HasColumnName("COD_ATRIBUTO");
            entity.Property(e => e.CodEstructuraReal)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_ESTRUCTURA_REAL");
            entity.Property(e => e.CodTipoEstructura)
                .HasPrecision(15)
                .HasColumnName("COD_TIPO_ESTRUCTURA");
            entity.Property(e => e.Codigo)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.CodigoDependiente)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CODIGO_DEPENDIENTE");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CODIGO_POSTAL");
            entity.Property(e => e.CuilJefe)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CUIL_JEFE");
            entity.Property(e => e.DescAtributo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("DESC_ATRIBUTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("DOMICILIO");
            entity.Property(e => e.EstructuraDependienteCod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ESTRUCTURA_DEPENDIENTE_COD");
            entity.Property(e => e.EstructuraDependienteDesc)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ESTRUCTURA_DEPENDIENTE_DESC");
            entity.Property(e => e.EstructuraDependienteId)
                .HasPrecision(15)
                .HasColumnName("ESTRUCTURA_DEPENDIENTE_ID");
            entity.Property(e => e.EstructuraId)
                .HasPrecision(15)
                .HasColumnName("ESTRUCTURA_ID");
            entity.Property(e => e.FechaOrigen)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_ORIGEN");
            entity.Property(e => e.Localidad)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("LOCALIDAD");
            entity.Property(e => e.NombreJefe)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_JEFE");
            entity.Property(e => e.NroOficina)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("NRO_OFICINA");
            entity.Property(e => e.Pais)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PAIS");
            entity.Property(e => e.Partido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PARTIDO");
            entity.Property(e => e.Piso)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("PISO");
            entity.Property(e => e.PosicionCodigo)
                .HasPrecision(5)
                .HasColumnName("POSICION_CODIGO");
            entity.Property(e => e.Provincia)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PROVINCIA");
            entity.Property(e => e.Telefono)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.TipoEstructuraDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TIPO_ESTRUCTURA_DESC");
            entity.Property(e => e.TipoEstructuraFormal)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TIPO_ESTRUCTURA_FORMAL");
            entity.Property(e => e.UiDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UI_DESC");
            entity.Property(e => e.UrDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UR_DESC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
