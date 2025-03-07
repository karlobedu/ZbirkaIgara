using System;
using System.Collections.Generic;

namespace ZbirkaIgara.Models;

public partial class Zanr
{
    public int Id { get; set; }

    public string ImeZanra { get; set; } = null!;

    public virtual ICollection<Igra> Igre { get; set; } = new List<Igra>();
}
