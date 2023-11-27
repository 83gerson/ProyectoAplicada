using System;
using System.Collections.Generic;

namespace WoofChef.Models;

public partial class TbExpediente
{
    public int Id { get; set; }

    public string NombreDuenno { get; set; } = null!;

    public string NombreMascota { get; set; } = null!;

    public string DescripcionMascota { get; set; } = null!;

    public string EnfermedadesYalergias { get; set; } = null!;
}
