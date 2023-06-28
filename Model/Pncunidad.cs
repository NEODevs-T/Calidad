using System;
using System.Collections.Generic;

namespace Calidad.Model;

public partial class Pncunidad
{
    public int IdUnidad { get; set; }

    public string Unombre { get; set; } = null!;

    public string? Udescri { get; set; }

    public bool Uestado { get; set; }

    public virtual ICollection<ProNoCon> ProNoCons { get; set; } = new List<ProNoCon>();
}
