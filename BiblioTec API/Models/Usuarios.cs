using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string Correo { get; set; } = null!;

    public int IdRol { get; set; }

    public virtual Administradores? Administradore { get; set; }

    public virtual Estudiantes? Estudiante { get; set; }

    public virtual Roles IdRolNavigation { get; set; } = null!;

    public virtual Maestros? Maestro { get; set; }

    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();

    public virtual PublicoGeneral? PublicoGeneral { get; set; }
}
