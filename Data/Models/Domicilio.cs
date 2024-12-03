using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Domicilio
{
    public int IdDomicilio { get; set; }

    public string Calle { get; set; } = null!;

    public int Numero { get; set; }

    public int? Piso { get; set; }

    public string? Depto { get; set; }

    public string? Descripcion { get; set; }

    public int IdLocalidad { get; set; }

    public Guid? IdUsuario { get; set; }

    public virtual ICollection<Envio> EnvioIdDestinoNavigations { get; set; } = new List<Envio>();

    public virtual ICollection<Envio> EnvioIdOrigenNavigations { get; set; } = new List<Envio>();

    public virtual Localidad IdLocalidadNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
