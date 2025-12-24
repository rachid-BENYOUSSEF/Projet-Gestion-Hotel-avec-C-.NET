using System;
using System.Collections.Generic;

namespace gestionhotel.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? Adresse { get; set; }

    public string? Email { get; set; }

    public int? FideliteId { get; set; }

    public string? Historique { get; set; }

    public string? Nom { get; set; }

    public string? NumeroTelephone { get; set; }

    public string? Preference { get; set; }

    public string? Prenom { get; set; }

    public virtual Fidelite? Fidelite { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
