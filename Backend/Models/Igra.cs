﻿using System;
using System.Collections.Generic;

namespace ZbirkaIgara.Models;

public partial class Igra
{
    public int Id { get; set; }

    public int? IdZanra { get; set; }

    public string Naslov { get; set; } = null!;

    public string? Opis { get; set; }

    public int? Hltb { get; set; }

    public DateOnly? DatumIzdavanja { get; set; }

    public string? Platforme { get; set; }

    public string? Trailer { get; set; }

    public string? UrlSlike { get; set; }
}
