using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Envio
{
    public long NroSeguimiento { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public decimal PesoGramos { get; set; }

    public Guid IdCliente { get; set; }

    public int IdEstado { get; set; }

    public int IdOrigen { get; set; }

    public int IdDestino { get; set; }

    public virtual Usuario IdClienteNavigation { get; set; } = null!;

    public virtual Domicilio IdDestinoNavigation { get; set; } = null!;

    public virtual EstadoEnvio IdEstadoNavigation { get; set; } = null!;

    public virtual Domicilio IdOrigenNavigation { get; set; } = null!;

    public virtual Viaje? Viaje { get; set; }
}
