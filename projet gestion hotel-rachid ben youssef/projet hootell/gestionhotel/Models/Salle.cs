using System;
using System.Collections.Generic;

namespace gestionhotel.Models;

public partial class Salle
{
    public int SalleId { get; set; }

    public int? CapaciteSalle { get; set; }

    public string? EquipementSalle { get; set; }

    public string? NomSalle { get; set; }

    public string? StatutSalle { get; set; }

    public double? TarifSalle { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
