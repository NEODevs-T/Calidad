using System;
using System.Collections.Generic;

namespace Calidad.Model;

public partial class Pncidentif
{
    public int IdIdentif { get; set; }

    public string Inombre { get; set; } = null!;

    public string? Idescri { get; set; }

    public bool Iestado { get; set; }

    public virtual ICollection<ProNoCon> ProNoCons { get; set; } = new List<ProNoCon>();
}
