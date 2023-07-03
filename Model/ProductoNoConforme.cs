using System;
using System.Collections.Generic;

namespace Calidad.Model;

public partial class ProductoNoConforme
{
    public int IdRegistro { get; set; }

    public string? Consecutivo { get; set; }

    public string CodigoDeProducto { get; set; } = null!;

    public string DescripcionDeProducto { get; set; } = null!;

    public string? Lote { get; set; }

    public string NoConformidad { get; set; } = null!;

    public string? Causa { get; set; }

    public int Cantidad { get; set; }

    public string? CausaDeLiberación { get; set; }

    public string? IndicacionDeLiberacion { get; set; }

    public string FichaDelCargador { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string DisposicionDefinitiva { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Riesgo { get; set; } = null!;

    public string Causante { get; set; } = null!;

    public string Unidad { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public string AlternativaPropuestoDeDisposicion { get; set; } = null!;

    public string LugarEvento { get; set; } = null!;

    public DateTime Fecha { get; set; }
}
