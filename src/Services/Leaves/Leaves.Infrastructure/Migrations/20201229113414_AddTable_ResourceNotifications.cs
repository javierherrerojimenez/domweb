using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leaves.Infrastructure.Migrations
{
    public partial class AddTable_ResourceNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RESOURCE_NOTIFICATIONS",
                schema: "leaves_db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESOURCE_NOTIFICATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESOURCE_NOTIFICATIONS_RESOURCES_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "leaves_db",
                        principalTable: "RESOURCES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RESOURCE_NOTIFICATIONS_ResourceId",
                schema: "leaves_db",
                table: "RESOURCE_NOTIFICATIONS",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RESOURCE_NOTIFICATIONS",
                schema: "leaves_db");
        }
    }
}
