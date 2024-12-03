using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class EstadoEnvio
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();
}
