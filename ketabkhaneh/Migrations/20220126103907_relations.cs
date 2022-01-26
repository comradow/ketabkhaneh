using Microsoft.EntityFrameworkCore.Migrations;

namespace ketabkhaneh.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Loans_BookAndMagId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId",
                table: "Loans");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookAndMagId",
                table: "Loans",
                column: "BookAndMagId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Loans_BookAndMagId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId",
                table: "Loans");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookAndMagId",
                table: "Loans",
                column: "BookAndMagId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId",
                unique: true);
        }
    }
}
