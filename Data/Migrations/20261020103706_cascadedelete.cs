using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment02.Migrations
{
    /// <inheritdoc />
    public partial class cascadedelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stucrsres_students_StudentId",
                table: "stucrsres");

            migrationBuilder.AddForeignKey(
                name: "FK_stucrsres_students_StudentId",
                table: "stucrsres",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stucrsres_students_StudentId",
                table: "stucrsres");

            migrationBuilder.AddForeignKey(
                name: "FK_stucrsres_students_StudentId",
                table: "stucrsres",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
