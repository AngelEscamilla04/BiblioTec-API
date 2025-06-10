using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class Maestros
{
    public int IdMaestro { get; set; }

    public int NoEmpleado { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
