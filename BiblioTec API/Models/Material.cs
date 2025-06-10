using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class Material
{
    public int IdMaterial { get; set; }

    public string? Titulo { get; set; }

    public string? Autor { get; set; }

    public int? AnioPublicacion { get; set; }

    public string? Editorial { get; set; }

    public int? IdTipoMaterial { get; set; }

    public virtual ICollection<Ejemplares> Ejemplares { get; set; } = new List<Ejemplares>();

    public virtual TipoMaterial? oTipoMaterial { get; set; }
}
