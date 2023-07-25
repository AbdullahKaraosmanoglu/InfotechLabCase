using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfotechLabCase.Migrations
{
    /// <inheritdoc />
    public partial class BugFixesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpertEmail",
                table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "ExpertPassword",
                table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "TblCustomer");

            migrationBuilder.DropColumn(
                name: "CustomerPassword",
                table: "TblCustomer");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TblExpert",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPostCode",
                table: "TblCustomer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TblCustomer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TblCity",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCity", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "TblDistrict",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDistrict", x => x.DistrictId);
                });

            migrationBuilder.CreateTable(
                name: "TblExpertComment",
                columns: table => new
                {
                    ExpertCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertComment = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateSystemDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblExpertComment", x => x.ExpertCommentId);
                });

            migrationBuilder.CreateTable(
                name: "TblNeighbourhood",
                columns: table => new
                {
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    NeighbourhoodName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblNeighbourhood", x => x.NeighbourhoodId);
                });

            migrationBuilder.CreateTable(
                name: "TblRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRole", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TblUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateSystemDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUser", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCity");

            migrationBuilder.DropTable(
                name: "TblDistrict");

            migrationBuilder.DropTable(
                name: "TblExpertComment");

            migrationBuilder.DropTable(
                name: "TblNeighbourhood");

            migrationBuilder.DropTable(
                name: "TblRole");

            migrationBuilder.DropTable(
                name: "TblUser");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TblExpert");

            migrationBuilder.DropColumn(
                name: "CustomerPostCode",
                table: "TblCustomer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TblCustomer");

            migrationBuilder.AddColumn<string>(
                name: "ExpertEmail",
                table: "TblExpert",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpertPassword",
                table: "TblExpert",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "TblCustomer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPassword",
                table: "TblCustomer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
