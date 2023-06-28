using System;
using System.Collections.Generic;

namespace Calidad.Model;

public partial class Pncestado
{
    public int IdEstado { get; set; }

    public string Enombre { get; set; } = null!;

    public string? Edescri { get; set; }

    public bool Estatus { get; set; }

    public virtual ICollection<ProNoCon> ProNoCons { get; set; } = new List<ProNoCon>();
}
