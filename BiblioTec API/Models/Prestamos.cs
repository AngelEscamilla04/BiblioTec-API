using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class Prestamos
{
    public int IdPrestamo { get; set; }

    public int IdUsuario { get; set; }

    public int IdEjemplar { get; set; }

    public string? EstadoLibro { get; set; }

    public DateOnly FechaPrestamo { get; set; }

    public DateOnly FechaLimite { get; set; }

    public virtual Ejemplares IdEjemplarNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Sanciones> Sanciones { get; set; } = new List<Sanciones>();
}
