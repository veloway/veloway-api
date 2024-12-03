using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Localidad
{
    public int IdLocalidad { get; set; }

    public int CodigoPostal { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdProvincia { get; set; }

    public virtual ICollection<Domicilio> Domicilios { get; set; } = new List<Domicilio>();

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
}
