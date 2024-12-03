using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class FichaMedica
{
    public int IdFichaMedica { get; set; }

    public string Observaciones { get; set; } = null!;

    public string TelefonoEmergencia { get; set; } = null!;

    public Guid IdConductor { get; set; }

    public virtual Conductor IdConductorNavigation { get; set; } = null!;
}
