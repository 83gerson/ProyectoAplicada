using System;
using System.Collections.Generic;

namespace WoofChef.Models;

public partial class TbIngrediente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Cantidad { get; set; }

    public virtual ICollection<TbProducto> IdProductos { get; set; } = new List<TbProducto>();
}
