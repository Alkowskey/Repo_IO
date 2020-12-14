using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationAppAPI.Migrations
{
    public partial class reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Flights_FlightId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_People_CustomerPersonId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservation_ReservationId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_FlightId",
                table: "Reservations",
                newName: "IX_Reservations_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_CustomerPersonId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Flights_FlightId",
                table: "Reservations",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_People_CustomerPersonId",
                table: "Reservations",
                column: "CustomerPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservations_ReservationId",
                table: "Tickets",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Flights_FlightId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_People_CustomerPersonId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservations_ReservationId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_FlightId",
                table: "Reservation",
                newName: "IX_Reservation_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerPersonId",
                table: "Reservation",
                newName: "IX_Reservation_CustomerPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Flights_FlightId",
                table: "Reservation",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_People_CustomerPersonId",
                table: "Reservation",
                column: "CustomerPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservation_ReservationId",
                table: "Tickets",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
