using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMmanagement.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classe_GetTrainerDtO_TrainerId",
                table: "Classe");

            migrationBuilder.DropTable(
                name: "GetTrainerDtO");

            migrationBuilder.AddForeignKey(
                name: "FK_Classe_AspNetUsers_TrainerId",
                table: "Classe",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classe_AspNetUsers_TrainerId",
                table: "Classe");

            migrationBuilder.CreateTable(
                name: "GetTrainerDtO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTrainerDtO", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Classe_GetTrainerDtO_TrainerId",
                table: "Classe",
                column: "TrainerId",
                principalTable: "GetTrainerDtO",
                principalColumn: "Id");
        }
    }
}
