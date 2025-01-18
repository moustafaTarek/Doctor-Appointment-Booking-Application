using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doctor.Availability.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Slots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "StatusId",
                table: "Slots",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
