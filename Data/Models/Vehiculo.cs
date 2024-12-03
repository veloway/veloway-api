using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string Patente { get; set; } = null!;

    public int Anio { get; set; }

    public string Color { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string NombreSeguro { get; set; } = null!;

    public int IdModelo { get; set; }

    public int IdTipoVehiculo { get; set; }

    public virtual Conductor? Conductore { get; set; }

    public virtual Modelo IdModeloNavigation { get; set; } = null!;

    public virtual TipoVehiculo IdTipoVehiculoNavigation { get; set; } = null!;
}
