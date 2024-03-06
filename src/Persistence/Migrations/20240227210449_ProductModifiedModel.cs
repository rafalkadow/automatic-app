using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PlcDriverModifiedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeToUtc",
                schema: "dbo",
                table: "PlcDriver",
                newName: "DateUtc");

            migrationBuilder.RenameColumn(
                name: "DateTimeFromUtc",
                schema: "dbo",
                table: "PlcDriver",
                newName: "DateTimeUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateUtc",
                schema: "dbo",
                table: "PlcDriver",
                newName: "DateTimeToUtc");

            migrationBuilder.RenameColumn(
                name: "DateTimeUtc",
                schema: "dbo",
                table: "PlcDriver",
                newName: "DateTimeFromUtc");
        }
    }
}
