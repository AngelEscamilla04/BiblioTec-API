using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class PublicoGeneral
{
    public int IdPublico { get; set; }

    public string? Curp { get; set; }

    public string? Correo { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
