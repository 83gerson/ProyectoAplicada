using System;
using System.Collections.Generic;

namespace WoofChef.Models;

public partial class TbVenta
{
    public int Id { get; set; }

    public int Monto { get; set; }

    public DateTime? Fecha { get; set; }

    public int IdCliente { get; set; }

    public virtual TbUsuario IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<TbVentasProducto> TbVentasProductos { get; set; } = new List<TbVentasProducto>();
}
