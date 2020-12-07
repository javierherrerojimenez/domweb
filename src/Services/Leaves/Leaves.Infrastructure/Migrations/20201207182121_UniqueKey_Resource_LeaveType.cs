using Microsoft.EntityFrameworkCore.Migrations;

namespace Leaves.Infrastructure.Migrations
{
    public partial class UniqueKey_Resource_LeaveType : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "leaves_db",
                table: "LEAVE_TYPES",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RESOURCES_ResourceCode",
                schema: "leaves_db",
                table: "RESOURCES",
                column: "ResourceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LEAVE_TYPES_Code",
                schema: "leaves_db",
                table: "LEAVE_TYPES",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RESOURCES_ResourceCode",
                schema: "leaves_db",
                table: "RESOURCES");

            migrationBuilder.DropIndex(
                name: "IX_LEAVE_TYPES_Code",
                schema: "leaves_db",
                table: "LEAVE_TYPES");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceCode",
                schema: "leaves_db",
                table: "RESOURCES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "leaves_db",
                table: "LEAVE_TYPES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
