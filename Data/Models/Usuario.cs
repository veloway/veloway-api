using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public int Dni { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly FechaNac { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public bool EsConductor { get; set; }

    public string? Telefono { get; set; }

    public virtual Conductor? Conductore { get; set; }

    public virtual Domicilio? Domicilio { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();
}
