using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Conductor
{
    public Guid IdConductor { get; set; }

    public int Dni { get; set; }

    public bool Compartirfichamedica { get; set; }

    public int IdEstado { get; set; }

    public int IdVehiculo { get; set; }

    public virtual FichaMedica? FichasMedica { get; set; }

    public virtual Usuario IdConductorNavigation { get; set; } = null!;

    public virtual EstadoConductor IdEstadoNavigation { get; set; } = null!;

    public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;

    public virtual Licencia? Licencia { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
