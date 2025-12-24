using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestionhotel.Migrations.Hotel
{
    /// <inheritdoc />
    public partial class Addclient_idToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chambre",
                columns: table => new
                {
                    chambre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacite = table.Column<int>(type: "int", nullable: true),
                    description_chambre = table.Column<string>(type: "text", nullable: true),
                    statut_chambre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tarif_par_nuit = table.Column<double>(type: "float", nullable: true),
                    type_chambre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chambre__645F7B5E5708DAC0", x => x.chambre_id);
                });

            migrationBuilder.CreateTable(
                name: "fidelite",
                columns: table => new
                {
                    fidelite_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    niveau_fidelite = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    offre_fidelite = table.Column<string>(type: "text", nullable: true),
                    points_fidelite = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__fidelite__ACA6C5FEDE1E3CF0", x => x.fidelite_id);
                });

            migrationBuilder.CreateTable(
                name: "salle",
                columns: table => new
                {
                    salle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacite_salle = table.Column<int>(type: "int", nullable: true),
                    equipement_salle = table.Column<string>(type: "text", nullable: true),
                    nom_salle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    statut_salle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tarif_salle = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__salle__D882AF9BFF90B9B6", x => x.salle_id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adresse = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fidelite_id = table.Column<int>(type: "int", nullable: true),
                    historique = table.Column<string>(type: "text", nullable: true),
                    nom = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    numero_telephone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    preference = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    prenom = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__client__BF21A424FE661190", x => x.client_id);
                    table.ForeignKey(
                        name: "FK__client__fidelite__571DF1D5",
                        column: x => x.fidelite_id,
                        principalTable: "fidelite",
                        principalColumn: "fidelite_id");
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    reservation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chambre_id = table.Column<int>(type: "int", nullable: true),
                    salle_id = table.Column<int>(type: "int", nullable: true),
                    service_id = table.Column<int>(type: "int", nullable: true),
                    date_debut = table.Column<DateTime>(type: "datetime", nullable: true),
                    date_fin = table.Column<DateTime>(type: "datetime", nullable: true),
                    date_reservation = table.Column<DateTime>(type: "datetime", nullable: true),
                    statut_reservation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    type_reservation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reservat__31384C29D704375C", x => x.reservation_id);
                    table.ForeignKey(
                        name: "FK__reservati__chamb__5070F446",
                        column: x => x.chambre_id,
                        principalTable: "chambre",
                        principalColumn: "chambre_id");
                    table.ForeignKey(
                        name: "FK__reservati__salle__5165187F",
                        column: x => x.salle_id,
                        principalTable: "salle",
                        principalColumn: "salle_id");
                    table.ForeignKey(
                        name: "FK_reservation_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description_service = table.Column<string>(type: "text", nullable: true),
                    nom_service = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    reservation_id = table.Column<int>(type: "int", nullable: true),
                    statut_service = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__service__3E0DB8AF71EF99C2", x => x.service_id);
                    table.ForeignKey(
                        name: "FK__service__reserva__5441852A",
                        column: x => x.reservation_id,
                        principalTable: "reservation",
                        principalColumn: "reservation_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_fidelite_id",
                table: "client",
                column: "fidelite_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_chambre_id",
                table: "reservation",
                column: "chambre_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_client_id",
                table: "reservation",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_salle_id",
                table: "reservation",
                column: "salle_id");

            migrationBuilder.CreateIndex(
                name: "IX_service_reservation_id",
                table: "service",
                column: "reservation_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "chambre");

            migrationBuilder.DropTable(
                name: "salle");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "fidelite");
        }
    }
}
