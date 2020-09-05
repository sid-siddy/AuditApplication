using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditManagement.Migrations
{
    public partial class fkchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditRequest_Auditors_AuditorFK",
                table: "AuditRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_Auditors_AuditorFK",
                table: "Portfolio");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_AuditorFK",
                table: "Portfolio");

            migrationBuilder.DropIndex(
                name: "IX_AuditRequest_AuditorFK",
                table: "AuditRequest");

            migrationBuilder.DropColumn(
                name: "AuditorFK",
                table: "AuditRequest");

            migrationBuilder.AddColumn<int>(
                name: "AuditorId",
                table: "Portfolio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuditorId",
                table: "AuditRequest",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditorId",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "AuditorId",
                table: "AuditRequest");

            migrationBuilder.AddColumn<int>(
                name: "AuditorFK",
                table: "AuditRequest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_AuditorFK",
                table: "Portfolio",
                column: "AuditorFK");

            migrationBuilder.CreateIndex(
                name: "IX_AuditRequest_AuditorFK",
                table: "AuditRequest",
                column: "AuditorFK");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditRequest_Auditors_AuditorFK",
                table: "AuditRequest",
                column: "AuditorFK",
                principalTable: "Auditors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_Auditors_AuditorFK",
                table: "Portfolio",
                column: "AuditorFK",
                principalTable: "Auditors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
