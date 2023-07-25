using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfotechLabCase.Migrations
{
    /// <inheritdoc />
    public partial class modelupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressExpert",
                table: "TblExpert",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressCustomer",
                table: "TblCustomer",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "Address",
        table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "TblCustomer");
        }
    }
}
