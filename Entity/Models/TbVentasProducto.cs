using System;
using System.Collections.Generic;

namespace WoofChef.Models;

public partial class TbVentasProducto
{
    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int CantidadProductos { get; set; }

    public virtual TbProducto IdProductoNavigation { get; set; } = null!;

    public virtual TbVenta IdVentaNavigation { get; set; } = null!;
}
