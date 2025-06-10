using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class Ejemplares
{
    public int IdEjemplar { get; set; }

    public int IdMaterial { get; set; }

    public string? CodigoInventario { get; set; }

    public virtual Material IdMaterialNavigation { get; set; } = null!;

    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();
}
