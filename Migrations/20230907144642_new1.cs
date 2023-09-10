using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMmanagement.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainerUserName",
                table: "Classe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainerUserName",
                table: "Classe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
