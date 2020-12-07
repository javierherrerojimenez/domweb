using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leaves.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "leaves_db");

            migrationBuilder.CreateTable(
                name: "LEAVE_STATUS",
                schema: "leaves_db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVE_STATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LEAVE_TYPES",
                schema: "leaves_db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVE_TYPES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESOURCES",
                schema: "leaves_db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESOURCES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LEAVES",
                schema: "leaves_db",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveStatusId = table.Column<int>(nullable: false),
                    LeaveTypeId = table.Column<int>(nullable: true),
                    LeaveReason_Name = table.Column<string>(nullable: true),
                    LeaveReason_Description = table.Column<string>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    IsNew = table.Column<bool>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LEAVES_LEAVE_TYPES_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalSchema: "leaves_db",
                        principalTable: "LEAVE_TYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LEAVES_LEAVE_STATUS_LeaveStatusId",
                        column: x => x.LeaveStatusId,
                        principalSchema: "leaves_db",
                        principalTable: "LEAVE_STATUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LEAVES_RESOURCES_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "leaves_db",
                        principalTable: "RESOURCES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LEAVES_LeaveTypeId",
                schema: "leaves_db",
                table: "LEAVES",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVES_LeaveStatusId",
                schema: "leaves_db",
                table: "LEAVES",
                column: "LeaveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVES_ResourceId",
                schema: "leaves_db",
                table: "LEAVES",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LEAVES",
                schema: "leaves_db");

            migrationBuilder.DropTable(
                name: "LEAVE_TYPES",
                schema: "leaves_db");

            migrationBuilder.DropTable(
                name: "LEAVE_STATUS",
                schema: "leaves_db");

            migrationBuilder.DropTable(
                name: "RESOURCES",
                schema: "leaves_db");
        }
    }
}
