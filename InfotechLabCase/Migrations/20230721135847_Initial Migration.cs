using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfotechLabCase.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    CustomerEmail = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CustomerPassword = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CustomerSurname = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CustomerDistrict = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CustomerNeighbourhood = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateSystemDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCustomer", x => x.CustormerId);
                });

            migrationBuilder.CreateTable(
                name: "TblServiceCategory",
                columns: table => new
                {
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePrice = table.Column<int>(type: "int", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblServiceCategory", x => x.ServiceCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TblExpert",
                columns: table => new
                {
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryId = table.Column<int>(type: "int", nullable: false),
                    ExpertEmail = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ExpertPassword = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ExpertName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ExpertSurname = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ExpertCity = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ExpertDistrict = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ExpertNeighbourhood = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ExpertPhone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateSystemDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblExpert", x => x.ExpertId);
                    table.ForeignKey(
                        name: "FK_TblExpert_TblServiceCategory_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "TblServiceCategory",
                        principalColumn: "ServiceCategoryId",
                        onDelete: ReferentialAction.Cascade);
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
                    OfferMessage = table.Column<string>(type: "nvarchar(350)", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateSystemDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOffer", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_TblOffer_TblCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "TblCustomer",
                        principalColumn: "CustormerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblOffer_TblExpert_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "TblExpert",
                        principalColumn: "ExpertId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblExpert_ServiceCategoryId",
                table: "TblExpert",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOffer_CustomerId",
                table: "TblOffer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOffer_ExpertId",
                table: "TblOffer",
                column: "ExpertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblOffer");

            migrationBuilder.DropTable(
                name: "TblCustomer");

            migrationBuilder.DropTable(
                name: "TblExpert");

            migrationBuilder.DropTable(
                name: "TblServiceCategory");
        }
    }
}
