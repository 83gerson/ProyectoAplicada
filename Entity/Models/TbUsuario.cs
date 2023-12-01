using System;
using System.Collections.Generic;

namespace WoofChef.Models;

public partial class TbUsuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasenna { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<TbVenta> TbVenta { get; set; } = new List<TbVenta>();
}
