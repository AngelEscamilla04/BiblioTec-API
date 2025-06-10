using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class Sanciones
{
    public int IdSancion { get; set; }

    public int IdPrestamo { get; set; }

    public decimal? MontoMulta { get; set; }

    public string? EstadoPago { get; set; }

    public DateOnly? FechaPago { get; set; }

    public virtual Prestamos IdPrestamoNavigation { get; set; } = null!;
}
