using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class TipoMaterial
{
    public int IdTipoMaterial { get; set; }

    public string? Nombre { get; set; }

    public decimal? Costo { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
