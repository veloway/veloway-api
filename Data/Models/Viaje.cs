using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Viaje
{
    public int IdViaje { get; set; }

    public int CheckpointActual { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public Guid IdConductor { get; set; }

    public long NroSeguimiento { get; set; }

    public virtual ICollection<Checkpoint> Checkpoints { get; set; } = new List<Checkpoint>();

    public virtual Conductor IdConductorNavigation { get; set; } = null!;

    public virtual Envio NroSeguimientoNavigation { get; set; } = null!;
}
