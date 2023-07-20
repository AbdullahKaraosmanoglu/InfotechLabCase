using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfotechLabCase.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCustomer",
                columns: table => new
                {
                    CustormerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerNeighbourhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<long>(type: "bigint", nullable: false),
                    CustomerTranDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCustomer", x => x.CustormerId);
                });

            migrationBuilder.CreateTable(
                name: "TblExpert",
                columns: table => new
                {
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertCategoryId = table.Column<int>(type: "int", nullable: false),
                    ExpertEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertNeighbourhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertPhone = table.Column<long>(type: "bigint", nullable: false),
                    ExpertTranDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
                    OfferStatus = table.Column<int>(type: "int", nullable: false),
                    OfferMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferTranDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ServiceCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePrice = table.Column<int>(type: "int", nullable: false)
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
