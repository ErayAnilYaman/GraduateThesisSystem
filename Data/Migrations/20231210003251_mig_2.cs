using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UNIVERSITYID",
                table: "UNIVERSITIES",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "UNIVERSITYID",
                table: "THESES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_THESES_UNIVERSITYID",
                table: "THESES",
                column: "UNIVERSITYID");

            migrationBuilder.AddForeignKey(
                name: "FK_THESES_UNIVERSITIES_UNIVERSITYID",
                table: "THESES",
                column: "UNIVERSITYID",
                principalTable: "UNIVERSITIES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_THESES_UNIVERSITIES_UNIVERSITYID",
                table: "THESES");

            migrationBuilder.DropIndex(
                name: "IX_THESES_UNIVERSITYID",
                table: "THESES");

            migrationBuilder.DropColumn(
                name: "UNIVERSITYID",
                table: "THESES");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UNIVERSITIES",
                newName: "UNIVERSITYID");
        }
    }
}
