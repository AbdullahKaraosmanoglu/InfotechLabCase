using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfotechLabCase.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerDistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerNeighbourhood = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateSystemDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCustomer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TblExpert",
                columns: table => new
                {
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
                    ExpertEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpertPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpertName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpertSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpertCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpertDistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpertNeighbourhood = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpertPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateSystemDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblExpert", x => x.ExpertId);
                });

            migrationBuilder.CreateTable(
                name: "TblOffer",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    OfferStatus = table.Column<int>(type: "int", nullable: false),
                    OfferMessage = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateSystemDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOffer", x => x.OfferId);
                });

            migrationBuilder.CreateTable(
                name: "TblServiceCategory",
                columns: table => new
                {
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServicePrice = table.Column<int>(type: "int", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateSystemDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblServiceCategory", x => x.ServiceCategoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCustomer");

            migrationBuilder.DropTable(
                name: "TblExpert");

            migrationBuilder.DropTable(
                name: "TblOffer");

            migrationBuilder.DropTable(
                name: "TblServiceCategory");
        }
    }
}
