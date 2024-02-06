using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class VwEstructura
{
    public long EstructuraId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? Abreviatura { get; set; }

    public long EstructuraDependienteId { get; set; }

    public string? CodigoDependiente { get; set; }

    public string? EstructuraDependienteDesc { get; set; }

    public DateTime FechaOrigen { get; set; }

    public string? CuilJefe { get; set; }

    public string? NombreJefe { get; set; }

    public string? ApellidoJefe { get; set; }

    public string? TipoEstructuraDesc { get; set; }

    public string? Domicilio { get; set; }

    public string? Localidad { get; set; }

    public string? Partido { get; set; }

    public string? Provincia { get; set; }

    public string? Pais { get; set; }

    public string? CodigoPostal { get; set; }

    public string? Telefono { get; set; }

    public string? Piso { get; set; }

    public string? NroOficina { get; set; }

    public string? TipoEstructuraFormal { get; set; }

    public string? UrDesc { get; set; }

    public string? UiDesc { get; set; }

    public byte? CodAtributo { get; set; }

    public string? DescAtributo { get; set; }

    public short? PosicionCodigo { get; set; }

    public long CodTipoEstructura { get; set; }

    public string? CodEstructuraReal { get; set; }

    public string? EstructuraDependienteCod { get; set; }
}
