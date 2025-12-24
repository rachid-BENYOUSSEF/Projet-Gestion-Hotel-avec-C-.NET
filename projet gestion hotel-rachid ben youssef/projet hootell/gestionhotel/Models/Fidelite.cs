using System;
using System.Collections.Generic;

namespace gestionhotel.Models;

public partial class Fidelite
{
    public int FideliteId { get; set; }

    public string? NiveauFidelite { get; set; }

    public string? OffreFidelite { get; set; }

    public int? PointsFidelite { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
