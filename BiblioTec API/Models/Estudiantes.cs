using System;
using System.Collections.Generic;

namespace BiblioTec_API.Models;

public partial class Estudiantes
{
    public int IdEstudiante { get; set; }

    public int Matricula { get; set; }

    public int IdUsuario { get; set; }

    public int IdCarrera { get; set; }

    public virtual Carreras IdCarreraNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
