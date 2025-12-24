using System;
using System.Collections.Generic;

namespace gestionhotel.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? DescriptionService { get; set; }

    public string? NomService { get; set; }

    public int? ReservationId { get; set; }

    public string? StatutService { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
