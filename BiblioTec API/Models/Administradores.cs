using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class Administradores
{
    public int IdAdministrador { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
