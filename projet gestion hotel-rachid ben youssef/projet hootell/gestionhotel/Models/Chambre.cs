using System;
using System.Collections.Generic;

namespace gestionhotel.Models;

public partial class Chambre
{
    public int ChambreId { get; set; }

    public int? Capacite { get; set; }

    public string? DescriptionChambre { get; set; }

    public string? StatutChambre { get; set; }

    public double? TarifParNuit { get; set; }

    public string? TypeChambre { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
