using System;
using System.Collections.Generic;

namespace Calidad.Model;

public partial class Pnccausante
{
    public int IdCausante { get; set; }

    public string Cnombre { get; set; } = null!;

    public string? Cdescri { get; set; }

    public bool Cestado { get; set; }

    public virtual ICollection<Pnccausa> Pnccausas { get; set; } = new List<Pnccausa>();
}
