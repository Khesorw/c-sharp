using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Client",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Client", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "NewsBoard",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Fee = table.Column<decimal>(type: "money", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NewsBoard", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Subscriptions",
            //    columns: table => new
            //    {
            //        ClientId = table.Column<int>(type: "int", nullable: false),
            //        NewsBoardId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Subscriptions", x => new { x.ClientId, x.NewsBoardId });
            //        table.ForeignKey(
            //            name: "FK_Subscriptions_Client_ClientId",
            //            column: x => x.ClientId,
            //            principalTable: "Client",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Subscriptions_NewsBoard_NewsBoardId",
            //            column: x => x.NewsBoardId,
            //            principalTable: "NewsBoard",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Subscriptions_NewsBoardId",
            //    table: "Subscriptions",
            //    column: "NewsBoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "NewsBoard");
        }
    }
}
