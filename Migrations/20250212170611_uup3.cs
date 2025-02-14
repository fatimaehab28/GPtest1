using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tbackendgp.Migrations
{
    /// <inheritdoc />
    public partial class uup3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AnnualGrossRent",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AnnualGrossYield",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AppreciationValue",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NetRentalIncome",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NetYield",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceOfMeterSquare",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PropertyValueGrowthPercentage",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalInvestmentReturn",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualGrossRent",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "AnnualGrossYield",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "AppreciationValue",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NetRentalIncome",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NetYield",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PriceOfMeterSquare",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyValueGrowthPercentage",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TotalInvestmentReturn",
                table: "Properties");
        }
    }
}
