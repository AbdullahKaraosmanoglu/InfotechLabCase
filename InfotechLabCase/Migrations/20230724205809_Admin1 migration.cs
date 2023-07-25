using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfotechLabCase.Migrations
{
    /// <inheritdoc />
    public partial class Admin1migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "TblAdmin");

            migrationBuilder.DropColumn(
                name: "ExpertId",
                table: "TblAdmin");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "TblAdmin");

            migrationBuilder.DropColumn(
                name: "ServiceCategoryId",
                table: "TblAdmin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "TblAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpertId",
                table: "TblAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "TblAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceCategoryId",
                table: "TblAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
