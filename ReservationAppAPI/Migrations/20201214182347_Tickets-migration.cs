using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationAppAPI.Migrations
{
    public partial class Ticketsmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_People_CustomerPersonId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Reservation_ReservationId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ReservationId",
                table: "Tickets",
                newName: "IX_Tickets_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_CustomerPersonId",
                table: "Tickets",
                newName: "IX_Tickets_CustomerPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_People_CustomerPersonId",
                table: "Tickets",
                column: "CustomerPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservation_ReservationId",
                table: "Tickets",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_People_CustomerPersonId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservation_ReservationId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ReservationId",
                table: "Ticket",
                newName: "IX_Ticket_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CustomerPersonId",
                table: "Ticket",
                newName: "IX_Ticket_CustomerPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_People_CustomerPersonId",
                table: "Ticket",
                column: "CustomerPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Reservation_ReservationId",
                table: "Ticket",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
