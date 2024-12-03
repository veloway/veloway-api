using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Licencia
{
    public int Numero { get; set; }

    public string Categoria { get; set; } = null!;

    public DateOnly Fechavencimiento { get; set; }

    public Guid IdConductor { get; set; }

    public virtual Conductor IdConductorNavigation { get; set; } = null!;
}
