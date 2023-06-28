using System;
using System.Collections.Generic;

namespace Calidad.Model;

public partial class PncdisDefi
{
    public int IdDisDefi { get; set; }

    public string Ddnombre { get; set; } = null!;

    public string? Dddescri { get; set; }

    public bool Ddestado { get; set; }

    public virtual ICollection<ProNoCon> ProNoCons { get; set; } = new List<ProNoCon>();
}
