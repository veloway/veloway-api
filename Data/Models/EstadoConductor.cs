﻿using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class EstadoConductor
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Conductor> Conductores { get; set; } = new List<Conductor>();
}