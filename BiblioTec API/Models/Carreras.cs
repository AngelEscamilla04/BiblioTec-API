﻿using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class Carreras
{
    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public virtual ICollection<Estudiantes> Estudiantes { get; set; } = new List<Estudiantes>();
}
