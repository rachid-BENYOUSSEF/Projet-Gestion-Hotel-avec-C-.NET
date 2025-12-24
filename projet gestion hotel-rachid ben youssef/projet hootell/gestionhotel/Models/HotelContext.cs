using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gestionhotel.Models;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
               /* public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Chambre> Chambres { get; set; }
    //public DbSet<Payment> Payments { get; set; }*/
}

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chambre> Chambres { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Fidelite> Fidelites { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Salle> Salles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=RACHID;Database=hotel;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chambre>(entity =>
        {
            entity.HasKey(e => e.ChambreId).HasName("PK__chambre__645F7B5E5708DAC0");

            entity.ToTable("chambre");

            entity.Property(e => e.ChambreId).HasColumnName("chambre_id");
            entity.Property(e => e.Capacite).HasColumnName("capacite");
            entity.Property(e => e.DescriptionChambre)
                .HasColumnType("text")
                .HasColumnName("description_chambre");
            entity.Property(e => e.StatutChambre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("statut_chambre");
            entity.Property(e => e.TarifParNuit).HasColumnName("tarif_par_nuit");
            entity.Property(e => e.TypeChambre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_chambre");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__client__BF21A424FE661190");

            entity.ToTable("client");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Adresse)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("adresse");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FideliteId).HasColumnName("fidelite_id");
            entity.Property(e => e.Historique)
                .HasColumnType("text")
                .HasColumnName("historique");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.NumeroTelephone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numero_telephone");
            entity.Property(e => e.Preference)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("preference");
            entity.Property(e => e.Prenom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("prenom");

            entity.HasOne(d => d.Fidelite).WithMany(p => p.Clients)
                .HasForeignKey(d => d.FideliteId)
                .HasConstraintName("FK__client__fidelite__571DF1D5");
        });

        modelBuilder.Entity<Fidelite>(entity =>
        {
            entity.HasKey(e => e.FideliteId).HasName("PK__fidelite__ACA6C5FEDE1E3CF0");

            entity.ToTable("fidelite");

            entity.Property(e => e.FideliteId).HasColumnName("fidelite_id");
            entity.Property(e => e.NiveauFidelite)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("niveau_fidelite");
            entity.Property(e => e.OffreFidelite)
                .HasColumnType("text")
                .HasColumnName("offre_fidelite");
            entity.Property(e => e.PointsFidelite).HasColumnName("points_fidelite");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__reservat__31384C29D704375C");

            entity.ToTable("reservation");

            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.ChambreId).HasColumnName("chambre_id");
            entity.Property(e => e.DateDebut)
                .HasColumnType("datetime")
                .HasColumnName("date_debut");
            entity.Property(e => e.DateFin)
                .HasColumnType("datetime")
                .HasColumnName("date_fin");
            entity.Property(e => e.DateReservation)
                .HasColumnType("datetime")
                .HasColumnName("date_reservation");
            entity.Property(e => e.SalleId).HasColumnName("salle_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.StatutReservation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("statut_reservation");
            entity.Property(e => e.TypeReservation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_reservation");

            entity.HasOne(d => d.Chambre).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ChambreId)
                .HasConstraintName("FK__reservati__chamb__5070F446");

            entity.HasOne(d => d.Salle).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.SalleId)
                .HasConstraintName("FK__reservati__salle__5165187F");
        });

        modelBuilder.Entity<Salle>(entity =>
        {
            entity.HasKey(e => e.SalleId).HasName("PK__salle__D882AF9BFF90B9B6");

            entity.ToTable("salle");

            entity.Property(e => e.SalleId).HasColumnName("salle_id");
            entity.Property(e => e.CapaciteSalle).HasColumnName("capacite_salle");
            entity.Property(e => e.EquipementSalle)
                .HasColumnType("text")
                .HasColumnName("equipement_salle");
            entity.Property(e => e.NomSalle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nom_salle");
            entity.Property(e => e.StatutSalle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("statut_salle");
            entity.Property(e => e.TarifSalle).HasColumnName("tarif_salle");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__service__3E0DB8AF71EF99C2");

            entity.ToTable("service");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.DescriptionService)
                .HasColumnType("text")
                .HasColumnName("description_service");
            entity.Property(e => e.NomService)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nom_service");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.StatutService)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("statut_service");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Services)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK__service__reserva__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
