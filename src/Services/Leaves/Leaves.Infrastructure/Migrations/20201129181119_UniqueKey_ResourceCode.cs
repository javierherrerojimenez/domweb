using Microsoft.EntityFrameworkCore.Migrations;

namespace Leaves.Infrastructure.Migrations
{
    public partial class UniqueKey_ResourceCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResourceCode",
                schema: "leaves_db",
                table: "RESOURCES",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RESOURCES_ResourceCode",
                schema: "leaves_db",
                table: "RESOURCES",
                column: "ResourceCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RESOURCES_ResourceCode",
                schema: "leaves_db",
                table: "RESOURCES");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceCode",
                schema: "leaves_db",
                table: "RESOURCES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
