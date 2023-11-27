﻿using System;
using System.Collections.Generic;

namespace WoofChef.Models;

public partial class TbProducto
{
    public int Id { get; set; }

    public string Receta { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int Cantidad { get; set; }

    public virtual ICollection<TbIngrediente> IdIngredientes { get; set; } = new List<TbIngrediente>();
}
