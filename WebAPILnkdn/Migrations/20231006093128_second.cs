using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPILnkdn.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalaryID",
                table: "people",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "personDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personDetails_people_PersonID",
                        column: x => x.PersonID,
                        principalTable: "people",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_positions_DepartmentID",
                table: "positions",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_people_SalaryID",
                table: "people",
                column: "SalaryID");

            migrationBuilder.CreateIndex(
                name: "IX_personDetails_PersonID",
                table: "personDetails",
                column: "PersonID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_people_salaries_SalaryID",
                table: "people",
                column: "SalaryID",
                principalTable: "salaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_positions_departments_DepartmentID",
                table: "positions",
                column: "DepartmentID",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_people_salaries_SalaryID",
                table: "people");

            migrationBuilder.DropForeignKey(
                name: "FK_positions_departments_DepartmentID",
                table: "positions");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "personDetails");

            migrationBuilder.DropTable(
                name: "salaries");

            migrationBuilder.DropIndex(
                name: "IX_positions_DepartmentID",
                table: "positions");

            migrationBuilder.DropIndex(
                name: "IX_people_SalaryID",
                table: "people");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "positions");

            migrationBuilder.DropColumn(
                name: "SalaryID",
                table: "people");
        }
    }
}
