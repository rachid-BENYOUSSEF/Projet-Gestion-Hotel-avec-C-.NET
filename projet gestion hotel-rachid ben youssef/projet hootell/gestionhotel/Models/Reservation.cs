using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionhotel.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }
    [ Required ]
    public int? ChambreId { get; set; }

    public int? SalleId { get; set; }

    public int? ServiceId { get; set; }

    public DateTime? DateDebut { get; set; }

    public DateTime? DateFin { get; set; }

    public DateTime? DateReservation { get; set; }

    public string? StatutReservation { get; set; }

    public string? TypeReservation { get; set; }

    [ForeignKey("client")]
    public int client_id { get; set; }

    public virtual Chambre? Chambre { get; set; }

    public virtual Salle? Salle { get; set; }


    public Client client { get; set; }
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
