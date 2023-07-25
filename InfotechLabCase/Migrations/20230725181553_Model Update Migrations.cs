using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfotechLabCase.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpertCity",
                table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "ExpertDistrict",
                table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "ExpertNeighbourhood",
                table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "CustomerCity",
                table: "TblCustomer");

            migrationBuilder.DropColumn(
                name: "CustomerDistrict",
                table: "TblCustomer");

            migrationBuilder.DropColumn(
                name: "CustomerNeighbourhood",
                table: "TblCustomer");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "TblExpert",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "TblExpert",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NeighbourhoodId",
                table: "TblExpert",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "TblCustomer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "TblCustomer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NeighbourhoodId",
                table: "TblCustomer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "NeighbourhoodId",
                table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "TblCustomer");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "TblCustomer");

            migrationBuilder.DropColumn(
                name: "NeighbourhoodId",
                table: "TblCustomer");

            migrationBuilder.AddColumn<string>(
                name: "ExpertCity",
                table: "TblExpert",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpertDistrict",
                table: "TblExpert",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpertNeighbourhood",
                table: "TblExpert",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerCity",
                table: "TblCustomer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerDistrict",
                table: "TblCustomer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerNeighbourhood",
                table: "TblCustomer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
