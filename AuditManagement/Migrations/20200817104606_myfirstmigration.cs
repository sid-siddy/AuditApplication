using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditManagement.Migrations
{
    public partial class myfirstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditorFK = table.Column<int>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    AuditorComments = table.Column<string>(nullable: true),
                    ClientResponse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditRequest", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_AuditRequest_Auditors_AuditorFK",
                        column: x => x.AuditorFK,
                        principalTable: "Auditors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    AuditId = table.Column<int>(nullable: false),
                    PortfolioName = table.Column<string>(maxLength: 50, nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    AuditorFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_Portfolio_Auditors_AuditorFK",
                        column: x => x.AuditorFK,
                        principalTable: "Auditors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditRequest_AuditorFK",
                table: "AuditRequest",
                column: "AuditorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_AuditorFK",
                table: "Portfolio",
                column: "AuditorFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditRequest");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "Auditors");
        }
    }
}
