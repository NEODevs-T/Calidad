using System;
using System.Collections.Generic;

namespace Calidad.Model;

public partial class PncproDisp
{
    public int IdProDisp { get; set; }

    public string Pdnombre { get; set; } = null!;

    public string? Pddescri { get; set; }

    public bool Pdestado { get; set; }

    public virtual ICollection<ProNoCon> ProNoCons { get; set; } = new List<ProNoCon>();
}
