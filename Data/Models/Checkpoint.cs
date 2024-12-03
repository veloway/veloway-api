using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Checkpoint
{
    public int IdCheckpoint { get; set; }

    public double Latitud { get; set; }

    public double Longitud { get; set; }

    public int Numero { get; set; }

    public int IdViaje { get; set; }

    public virtual Viaje IdViajeNavigation { get; set; } = null!;
}
